using System;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;

namespace Atividade02.Proposals.Domain.Proposals.Repositories
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        Task<Proposal> Get(string cpf, string cnpj);
        Task<List<Proposal>> GetAll(string? cpf, string? cnpj);
        Task<Proposal?> GetByAggregateId(string aggregateId);

    }
}

