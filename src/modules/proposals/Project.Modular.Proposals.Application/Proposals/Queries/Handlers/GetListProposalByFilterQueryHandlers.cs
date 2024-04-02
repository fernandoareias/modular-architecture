using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Application.Proposals.Queries;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Queries.Handlers
{
    public class GetListProposalByFilterQueryHandlers : IRequestHandler<GetListProposalByFilterQuery, View>
    {
        private readonly IProposalRepository _proposalRepository;

        public GetListProposalByFilterQueryHandlers(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public async Task<View> Handle(GetListProposalByFilterQuery request, CancellationToken cancellationToken)
        {
            var proposals = await _proposalRepository.GetAll(request.CPF, request.CNPJ);

            if (proposals is null || !proposals.Any()) return null!;

            return new GetListProposalByFilterQueryView(proposals);
        }
    }
}