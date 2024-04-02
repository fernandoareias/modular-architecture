using System;
namespace Atividade02.Proposals.Domain.Data.Common.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);

        IUnitOfWork unitOfWork { get; }
    }
}

