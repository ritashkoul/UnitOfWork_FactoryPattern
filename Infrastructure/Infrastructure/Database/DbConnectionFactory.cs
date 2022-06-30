using Infrastructure.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Infrastructure.Repositories;

namespace Infrastructure.Database
{
    public class DbConnectionFactory : IDbConnectionFactory, IDisposable
    {
        private readonly IDictionary<string, string> _connectionStrings;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }


        public DbConnectionFactory(IDictionary<string, string> connectionDictionary)
        {
            _connectionStrings = connectionDictionary;
            Connection = CreateSqlConnection();
            Connection.Open();
        }
        
        private string GetConnectionString(string connectionName)
        {
            _connectionStrings.TryGetValue(connectionName, out string connectionString);
            return connectionString;
        }

        public IDbConnection CreateSqlConnection()
        {
            DbConnection connection = null;

            string connectionString = GetConnectionString(DataAccessProviderTypes.SqlServer.ToString());
            if (connectionString != null)
            {
                return new SqlConnection(connectionString);
            }

            return connection;
        }

        public IDbConnection CreatePostgreSqlConnection()
        {
            DbConnection connection = null;

            string connectionString = GetConnectionString(DataAccessProviderTypes.PostgreSql.ToString());
            if (connectionString != null)
            {
                return new NpgsqlConnection(connectionString);
            }

            return connection;
        }
        
        public void Dispose() => Connection?.Dispose();
    }

    public enum DataAccessProviderTypes
    {
        SqlServer,
        PostgreSql
    }
}
