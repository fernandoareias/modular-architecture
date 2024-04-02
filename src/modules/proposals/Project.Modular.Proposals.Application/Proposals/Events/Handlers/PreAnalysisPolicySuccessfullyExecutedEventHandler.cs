using System;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Proposals.Application.Proposals.Commands;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Events.Handlers
{
    public class PreAnalysisPolicySuccessfullyExecutedEventHandler : INotificationHandler<PreAnalysisPolicySuccessfullyExecutedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PreAnalysisPolicySuccessfullyExecutedEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(PreAnalysisPolicySuccessfullyExecutedEvent notification, CancellationToken cancellationToken)
        {
            var command = new ExecuteFraudAnalysisPolicyCommand(notification.ProposalId);

            await _mediatorHandler.Send<ExecuteFraudAnalysisPolicyCommand>(command);
        }
    }
}

