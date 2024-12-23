using Npgsql;

namespace Infrostruckture.DataContext;

public interface IDapperContext
{
    NpgsqlConnection Connection();
}