using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Domain.Proposals.Services;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Commands.Handlers
{
    public class ExecuteFormalizationPolicyCommandHandler : IRequestHandler<ExecuteFormalizationPolicyCommand, View>
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IFormalizationPolicyServices _formalizationPolicyServices;

        public ExecuteFormalizationPolicyCommandHandler(IProposalRepository proposalRepository, IFormalizationPolicyServices formalizationPolicyServices)
        {
            _proposalRepository = proposalRepository;
            _formalizationPolicyServices = formalizationPolicyServices;
        }

        public async Task<View> Handle(ExecuteFormalizationPolicyCommand request, CancellationToken cancellationToken)
        {
            Proposal? proposal = await _proposalRepository.GetByAggregateId(request.Id);

            if (proposal is null)
                throw new InvalidOperationException("Proposal not exist!");

            await proposal.Execute(_formalizationPolicyServices);

            _proposalRepository.Update(proposal);

            await _proposalRepository.unitOfWork.Commit();

            return null;
        }
    }
}

