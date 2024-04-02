using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using MongoDB.Driver;

namespace Atividade02.Proposals.Infrastructure.Data.Common.Interfaces
{
    public interface IMongoContext : IUnitOfWork
    {
        void AddCommand(Func<Task> func, AggregateRoot? entity = null);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}

