using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Proponents;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Infrastructure.Data.Common.Interfaces;
using MongoDB.Driver;
using Notification.Worker.Data.Builders;
using Notification.Worker.Data.Repositories;

namespace Atividade02.Proposals.Infrastructure.Data.Repositories
{
    public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
    {
        private FindOptions<Proposal> _options;
        public ProposalRepository(IMongoContext context) : base(context)
        {
            _options = new FindOptions<Proposal>
            {
                MaxTime = TimeSpan.FromSeconds(5) // Defina o tempo limite desejado
            };
        }

        public async Task<Proposal> Get(string cpf, string cnpj)
        {
            var filter = Builders<Proposal>.Filter.And(
                Builders<Proposal>.Filter.Eq("Proponent.CPF.Number", cpf),
                Builders<Proposal>.Filter.Eq("Store.cnpj", cnpj)
                );

            var data = await DbSet.FindAsync(filter, _options);

            return data.FirstOrDefault();
        }

        public async Task<List<Proposal>> GetAll(string? cpf, string? cnpj)
        {
            var filter = new ProposalGetAllBuilder()
                                .AddCPF(cpf)
                                .AddCNPJ(cnpj)
                                .Build();

            var data = await DbSet.FindAsync(filter, _options);

            return await data.ToListAsync();
        }

        public async Task<Proposal?> GetByAggregateId(string aggregateId)
        {
            var options = new FindOptions<Proposal>
            {
                MaxTime = TimeSpan.FromSeconds(5) // Defina o tempo limite desejado
            };

            var filter = Builders<Proposal>.Filter.Eq("AggregateId", aggregateId);

            var data = await DbSet.FindAsync(filter, options);

            return data.FirstOrDefault();
        }
    }
}

