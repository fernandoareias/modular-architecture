using System;
using Amazon.Runtime.Internal;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Proposals.Application.Proposals.Commands;
using Atividade02.Proposals.Domain.Proposals.Events;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Events.Handlers
{
    public class ProposalSentEventHandler : INotificationHandler<ProposalSentEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ProposalSentEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProposalSentEvent notification, CancellationToken cancellationToken)
        {
            var command = new CreateProposalCommand(
                notification.AggregateId,
                notification.Name,
                notification.CPF,
                notification.CNPJ,
                notification.DDD,
                notification.Cellphone,
                notification?.Notes);

            await _mediatorHandler.Send<CreateProposalCommand>(command);
        }
         
    }
}

