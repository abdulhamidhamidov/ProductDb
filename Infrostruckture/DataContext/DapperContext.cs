using Npgsql;

namespace Infrostruckture.DataContext;

public class DapperContext : IDapperContext
{
    public string connectionString = "Server=localhost;Port=5432;Database=ProductDb;Username=postgres;Password=12345";
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}