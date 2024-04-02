using MediatR;
using Microsoft.AspNetCore.Mvc;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Core.Mediator.Interfaces;

public interface IMediatorHandler
{
    Task Publish<TEvent>(TEvent @event) where TEvent : Event;
    Task<View> Send<TCommand>(Command command) where TCommand : Command;
    Task<View> Execute<TQuery>(TQuery query) where TQuery : Query;
}