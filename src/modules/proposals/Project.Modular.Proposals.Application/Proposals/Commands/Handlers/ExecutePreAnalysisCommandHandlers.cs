using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Domain.Proposals.Services;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Commands.Handlers
{
    public class ExecutePreAnalysisCommandHandlers : IRequestHandler<ExecutePreAnalysisCommand, View>
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IPreAnalysisPolicyServices _preAnalysisPolicyServices;
        public ExecutePreAnalysisCommandHandlers(IProposalRepository proposalRepository, IPreAnalysisPolicyServices preAnalysisPolicyServices)
        {
            _proposalRepository = proposalRepository;
            _preAnalysisPolicyServices = preAnalysisPolicyServices;
        }

        public async Task<View> Handle(ExecutePreAnalysisCommand request, CancellationToken cancellationToken)
        {
            Proposal? proposal = await _proposalRepository.GetByAggregateId(request.Id);

            if (proposal is null)
                throw new InvalidOperationException("Proposal not exist!");

            await proposal.Execute(_preAnalysisPolicyServices);

            _proposalRepository.Update(proposal);

            await _proposalRepository.unitOfWork.Commit();

            return null;
        }
    }
}

