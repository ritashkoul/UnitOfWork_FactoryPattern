using Infrastructure.Database;
using System;

namespace Infrastructure.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>(DataAccessProviderTypes providerType) where TEntity : class;
        void BeginTransaction();
        void Commit();
        void Rollback();
        //void Dispose();
    }
}
