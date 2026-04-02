using System.Data;
using MySqlConnector;

namespace SysOpsServices.Infrastructure.Data;

public interface IDbConnectionFactory
{
    IDbConnection Create();
}

public class MariaDbConnectionFactory(string ConnectionString) : IDbConnectionFactory
{
    public IDbConnection Create() => new MySqlConnection(ConnectionString);
}
