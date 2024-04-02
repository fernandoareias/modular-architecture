using System;
namespace Atividade02.Proposals.Domain.Data.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}

