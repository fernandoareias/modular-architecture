using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Proposals.Application.Proposals.Commands;
using Atividade02.Proposals.Domain.Proposals.Events;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Events.Handlers
{
    public class ProposalCreatedEventHandlers : INotificationHandler<Domain.Proposals.Events.ProposalSentEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ProposalCreatedEventHandlers(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(Domain.Proposals.Events.ProposalSentEvent notification, CancellationToken cancellationToken)
        {
            var command = new ExecutePreAnalysisCommand(notification.Id);

            await _mediatorHandler.Send<ExecutePreAnalysisCommand>(command);
        }
    }
}

