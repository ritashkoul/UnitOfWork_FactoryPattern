using Infrastructure.Database;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private Dictionary<(Type type, string name), object> _repositories;
        private readonly IDbConnectionFactory _database;

        public RepositoryManager(IDbConnectionFactory database)
        {
            _database = database;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>(DataAccessProviderTypes providerType) where TEntity : class
        {
            if(providerType.Equals(DataAccessProviderTypes.SqlServer))
                return (IGenericRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new DapperSqlRepository<TEntity>(_database));
            else if(providerType.Equals(DataAccessProviderTypes.PostgreSql))
                return (IGenericRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new DapperPostgreSqlRepository<TEntity>(_database));

            return null;
        }

        private object GetOrAddRepository(Type type, object repo)
        {

            _repositories ??= new Dictionary<(Type type, string Name), object>();

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) 
                return repository;

            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }

        public void BeginTransaction() => _database.Transaction = _database.Connection.BeginTransaction();

        public void Commit()
        {
            _database.Transaction.Commit();
        }

        public void Rollback() => _database.Transaction.Rollback();

        public void Dispose()
        {
            _database.Transaction?.Dispose();
        }
    }
}
