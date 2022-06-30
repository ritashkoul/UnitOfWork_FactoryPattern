using Dapper;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DapperPostgreSqlRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnectionFactory _database;

        public DapperPostgreSqlRepository(IDbConnectionFactory database)
        {
            _database = database;
        }

        public List<T> GetAll(string sql)
        {
            using (IDbConnection connection = _database.CreatePostgreSqlConnection())
            {
                List<T> dataList = SqlMapper.Query<T>(connection, sql, CommandType.Text).ToList();

                return dataList;
            }
        }

        public void Insert(T param, string sql)
        {
            throw new System.NotImplementedException();
        }
    }
}
