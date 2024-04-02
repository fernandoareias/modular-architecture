using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Atividade02.Core.Common.CQRS;
using Atividade02.Core.Common.Domain;
using Atividade02.Core.MessageBus.Configurations;
using Atividade02.Core.MessageBus.DTOs;
using Atividade02.Core.MessageBus.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Atividade02.Core.MessageBus.Services;

public class MessageBus : IMessageBus
{
    public MessageBus(IOptions<MessageBusConfigs> config, ILogger<MessageBus> logger)
    {
        _busConfigs = config.Value;
        _logger = logger;
        factory = new ConnectionFactory { Uri = new Uri(_busConfigs.Host) };
    }

    private bool _isConnected = false;
    private IConnection _connection;
    private IModel _consumerChannel;
    private ConnectionFactory factory;

    private readonly IDictionary<string, string> _exchange = new Dictionary<string, string>();
    private readonly IDictionary<string, string> _routingKeys = new Dictionary<string, string>();

    private readonly MessageBusConfigs _busConfigs;
    private readonly ILogger<MessageBus> _logger;

    private IConnection connection
    {
        get
        {
            if (!_isConnected)
                Connect();

            return _connection;
        }
    }

    public void Connect()
    {
        var policy = RetryPolicy.Handle<SocketException>().Or<BrokerUnreachableException>()
            .WaitAndRetry(_busConfigs.RetryCount, op => TimeSpan.FromSeconds(Math.Pow(2, op)), (ex, time) =>
            {
                Console.WriteLine($"Couldn't connect to RabbitMQ {factory.Uri}");
            });

        policy.Execute(() =>
        {
            _connection = factory.CreateConnection();
            _isConnected = true;
        });
    }

    private void DeclareQueueAndExchange(string routingKey, string exchangeName, IModel channel, string? type = ExchangeType.Direct)
    {
        bool containsExchange = _exchange.ContainsKey(exchangeName);
        bool containsRoutingKey = _routingKeys.ContainsKey(routingKey);

        if (containsExchange && containsRoutingKey) return;

        if (!containsExchange)
        {
            channel.ExchangeDeclare(exchange: exchangeName, type: type, durable: true);
            _exchange.Add(exchangeName, exchangeName);
        }

        if (!containsRoutingKey)
        {
            channel.QueueDeclare(queue: routingKey, durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueBind(queue: routingKey, exchange: exchangeName, routingKey: routingKey);
            _routingKeys.Add(routingKey, routingKey);
        }

    }

    public void Publish(string exchange, string queue, dynamic command)
    {
        using (var channel = connection.CreateModel())
        {
            DeclareQueueAndExchange(queue, exchange, channel);

            string commandJson = JsonSerializer.Serialize(command);
            _logger.LogInformation($"[PUBLISH] - Exchange: {exchange} | Type: {ExchangeType.Direct.ToString()} | Queue: {queue} | RoutingKey: {queue} | Message: {commandJson}");

            var body = Encoding.UTF8.GetBytes(commandJson);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.Headers = new Dictionary<string, object>
            {
                { "X-Retry-Count", 0 }
            };

            channel.BasicPublish(exchange: exchange, routingKey: queue, basicProperties: properties, body: body);
        }
    }

    public void Subscribe<TMessage>(string exchange, string queue, Func<TMessage, Task> function, CancellationToken stoppingToken)
    {
        var consumerChannel = connection.CreateModel();
        DeclareQueueAndExchange(queue, exchange, consumerChannel);

        var consumer = new EventingBasicConsumer(consumerChannel);
        consumerChannel.BasicConsume(queue: queue, autoAck: false, consumer: consumer);

        consumer.Received += async (sender, eventArgs) =>
        {
            var messageBody = eventArgs.Body.ToArray();
            var messageJson = Encoding.UTF8.GetString(messageBody);
            try
            {

                var args = JsonSerializer.Deserialize<TMessage>(messageJson);
                _logger.LogInformation(
                    $"[SUBSCRIBE] - Exchange: {exchange} | Type: {ExchangeType.Direct.ToString()} | Queue: {queue} | RoutingKey: {queue} | Message: {messageJson}");

                await function(args);

                consumerChannel.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (DomainException domainException)
            {
                _logger.LogError($"[SUBSCRIBE][EXCEPTION] - Exchange: {exchange} | Queue: {queue} | RoutingKey: {queue} | Exception {domainException}");
                Publish(exchange + "-dead", queue + "-dead", new FailProcessCommand(messageJson, $"{domainException}"));
                consumerChannel.BasicNack(eventArgs.DeliveryTag, false, false);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SUBSCRIBE][EXCEPTION] - Exchange: {exchange} | Queue: {queue} | RoutingKey: {queue} | Exception {ex}");
                consumerChannel.BasicNack(eventArgs.DeliveryTag, false, true);
            }
        };


    }

    public Task<TResult> RPCClient<TResult>(string exchange, string routingKey, string correlationId, dynamic command)
    {
        var tcs = new TaskCompletionSource<TResult>();
        using var channel = connection.CreateModel();
        DeclareQueueAndExchange(routingKey, exchange, channel, null);


        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            try
            {
                if (ea.BasicProperties.CorrelationId == correlationId)
                {
                    var messageBody = ea.Body.ToArray();
                    var messageJson = Encoding.UTF8.GetString(messageBody);
                    var args = JsonSerializer.Deserialize<TResult>(messageJson);
                    tcs.SetResult(args);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"[RPC][CONSUME][EXCEPTION] - Exception: {ex}");
            }
        };



        string commandJson = JsonSerializer.Serialize(command);

        _logger.LogInformation($"[PUBLISH] - Exchange: {exchange} | Type: {ExchangeType.Direct.ToString()} | Queue: {routingKey} | RoutingKey: {routingKey} | Message: {commandJson}");

        var body = Encoding.UTF8.GetBytes(commandJson);

        string replyQueueName = routingKey + "-result";
        var properties = channel.CreateBasicProperties();

        properties.Persistent = true;
        properties.CorrelationId = correlationId;
        properties.ReplyTo = replyQueueName;

        channel.BasicPublish(exchange: exchange,
                             routingKey: routingKey,
                             basicProperties: properties,
                             body: body);

        channel.BasicConsume(consumer: consumer,
                              queue: replyQueueName,
                              autoAck: true);

        return tcs.Task;
    }

    public async void RPCServer<TMessage>(string exchange, string routingKey, Func<TMessage, Task> function, CancellationToken stoppingToken)
    {
        _consumerChannel = connection.CreateModel();
        DeclareQueueAndExchange(routingKey, exchange, _consumerChannel);

        var consumer = new EventingBasicConsumer(_consumerChannel);
        _consumerChannel.BasicConsume(queue: routingKey, autoAck: false, consumer: consumer);

        consumer.Received += async (sender, eventArgs) =>
        {
            try
            {
                var messageBody = eventArgs.Body.ToArray();
                var messageJson = Encoding.UTF8.GetString(messageBody);
                var args = JsonSerializer.Deserialize<TMessage>(messageJson);
                Console.WriteLine(
                    $"[SUBSCRIBE] - Exchange: {exchange} | Type: {ExchangeType.Direct.ToString()} | Queue: {routingKey} | RoutingKey: {routingKey} | Message: {messageJson}");

                await function(args);

                _consumerChannel.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SUBSCRIBE][EXCEPTION] - Exchange: {exchange} | Queue: {routingKey} | RoutingKey: {routingKey} | Exception {ex.Message}");
                _consumerChannel.BasicNack(eventArgs.DeliveryTag, false, true);
            }
        };
    }

    public void Dispose()
    {
        _connection?.Dispose();
        _consumerChannel?.Dispose();
    }


}