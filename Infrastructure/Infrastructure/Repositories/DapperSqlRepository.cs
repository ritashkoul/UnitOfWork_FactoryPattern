using Dapper;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DapperSqlRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnectionFactory _database;

        public DapperSqlRepository(IDbConnectionFactory database)
        {
            _database = database;
        }

        public List<T> GetAll(string sql)
        {
            List<T> dataList = SqlMapper.Query<T>(_database.Connection, sql, transaction: _database.Transaction, commandType: CommandType.StoredProcedure).ToList();
            return dataList;
        }

        public void Insert(T param, string sql)
        {
            _database.Connection.Execute(sql, param, transaction: _database.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
