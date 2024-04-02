using Atividade02.Core.Common.CQRS;

namespace Atividade02.Core.MessageBus.Services.Interfaces;



public interface IMessageBus : IDisposable
{
    void RPCServer<TMessage>(string exchange, string routingKey, Func<TMessage, Task> function, CancellationToken stoppingToken);
    Task<TResult> RPCClient<TResult>(string exchange, string routingKey, string correlationId, dynamic command);
    void Publish(string exchange, string queue, dynamic command);
    void Subscribe<TMessage>(string exchange, string queue, Func<TMessage, Task> function, CancellationToken stoppingToken);
}