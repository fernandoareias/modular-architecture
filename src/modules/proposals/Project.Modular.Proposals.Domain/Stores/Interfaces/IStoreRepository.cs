using System;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;

namespace Atividade02.Proposals.Domain.Stores.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task<Store?> GetByCNPJ(string cnpj);
    }
}

