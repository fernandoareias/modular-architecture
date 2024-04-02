using System;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Proponents;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;
using Atividade02.Proposals.Domain.Stores.Interfaces;
using Atividade02.Proposals.Infrastructure.Data.Common.Interfaces;
using MongoDB.Driver;
using Notification.Worker.Data.Repositories;

namespace Atividade02.Proposals.Infrastructure.Data.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<Store?> GetByCNPJ(string cnpj)
        {
            var data = await DbSet.FindAsync(Builders<Store>.Filter.Eq("cnpj", cnpj));
            return data.SingleOrDefault();
        }
    }
}

