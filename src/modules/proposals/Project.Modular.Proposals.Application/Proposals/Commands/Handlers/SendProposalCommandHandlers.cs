using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Core.Common.Domain;
using Atividade02.Core.MessageBus.Services.Interfaces;
using Atividade02.Proposals.Application.Proposals.Commands.Views;
using Atividade02.Proposals.Application.Proposals.Events;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities;
using Atividade02.Proposals.Domain.Proposals.Enums;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Domain.Stores.Interfaces;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Commands.Handlers
{
    public class SendProposalCommandHandlers : IRequestHandler<SendProposalCommand, View>
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IMessageBus _messageBus;

        public SendProposalCommandHandlers(
            IProposalRepository proposalRepository,
            IMessageBus messageBus)
        {
            _proposalRepository = proposalRepository;
            _messageBus = messageBus;
        }

        public async Task<View> Handle(SendProposalCommand request, CancellationToken cancellationToken)
        {
            // Proposal proposal = await _proposalRepository.Get(request.CPF, request.CNPJ);

            // if (proposal is not null)
            //     return new CreateProposalCommandView(proposal.AggregateId, proposal.Status.ToString());

            var @event = new ProposalSentEvent(
                request.AggregateId,
                request.Name,
                request.CPF,
                request.CNPJ,
                request.DDD,
                request.Cellphone,
                request?.Notes);

            _messageBus.Publish(@event.Exchange, @event.RouterKey, @event);

            return new SendProposalCommandView(request!.AggregateId.ToString(), EProposalStatus.PROCESSING.ToString());
        }
    }
}

