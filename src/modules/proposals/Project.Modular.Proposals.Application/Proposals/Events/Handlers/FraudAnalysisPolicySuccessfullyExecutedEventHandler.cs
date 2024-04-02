using System;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Proposals.Application.Proposals.Commands;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Events.Handlers
{
    public class FraudAnalysisPolicySuccessfullyExecutedEventHandler : INotificationHandler<FraudAnalysisPolicySuccessfullyExecutedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public FraudAnalysisPolicySuccessfullyExecutedEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(FraudAnalysisPolicySuccessfullyExecutedEvent notification, CancellationToken cancellationToken)
        {
            var command = new ExecuteFormalizationPolicyCommand(notification.ProposalId);

            await _mediatorHandler.Send<ExecuteFormalizationPolicyCommand>(command);
        }
    }
}

