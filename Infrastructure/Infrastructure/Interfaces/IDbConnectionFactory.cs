using System.Data;

namespace Infrastructure.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
        IDbConnection CreateSqlConnection();
        IDbConnection CreatePostgreSqlConnection();

    }
}
