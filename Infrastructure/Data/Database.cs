using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class Database
{
    private string connectionString = "Host=localhost;Port=5432;Database=ClassTask;Username=postgres;Password=1234";
    public IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
