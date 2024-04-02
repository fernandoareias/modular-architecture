using MediatR;
using Microsoft.AspNetCore.Mvc;
using Atividade02.Core.Common.CQRS;
using Atividade02.Core.Mediator.Interfaces;

namespace Atividade02.Core.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;
    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<View> Execute<TQuery>(TQuery query) where TQuery : Query
    {
        return await _mediator.Send(query);
    }

    public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
    {
        await _mediator.Publish(@event);
    }

    public async Task<View> Send<TCommand>(Command command) where TCommand : Command
    {
        return await _mediator.Send(command);
    }

}