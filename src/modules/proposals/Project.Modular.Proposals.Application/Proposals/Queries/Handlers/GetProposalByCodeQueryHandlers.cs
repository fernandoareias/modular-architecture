using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Queries.Handlers
{
    public class GetProposalByCodeQueryHandlers : IRequestHandler<GetProposalByAggregateIdQuery, View>
    {
        private readonly IProposalRepository _proposalRepository;

        public GetProposalByCodeQueryHandlers(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public async Task<View> Handle(GetProposalByAggregateIdQuery request, CancellationToken cancellationToken)
        {
            var proposal = await _proposalRepository.GetByAggregateId(request.AggregateId);

            if (proposal is null) return null!;

            return new GetProposalByCodeQueryView(proposal);
        }
    }
}