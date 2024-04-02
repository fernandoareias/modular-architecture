using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Domain.Proposals.Services;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Commands.Handlers
{
    public class ExecuteFraudAnalysisPolicyCommandHandler : IRequestHandler<ExecuteFraudAnalysisPolicyCommand, View>
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IFraudAnalysisPolicyServices _fraudAnalysisPolicyServices;

        public ExecuteFraudAnalysisPolicyCommandHandler(IProposalRepository proposalRepository, IFraudAnalysisPolicyServices fraudAnalysisPolicyServices)
        {
            _proposalRepository = proposalRepository;
            _fraudAnalysisPolicyServices = fraudAnalysisPolicyServices;
        }

        public async Task<View> Handle(ExecuteFraudAnalysisPolicyCommand request, CancellationToken cancellationToken)
        {
            Proposal? proposal = await _proposalRepository.GetByAggregateId(request.Id);

            if (proposal is null)
                throw new InvalidOperationException("Proposal not exist!");

            await proposal.Execute(_fraudAnalysisPolicyServices);

            _proposalRepository.Update(proposal);

            await _proposalRepository.unitOfWork.Commit();

            return null;
        }
    }
}

