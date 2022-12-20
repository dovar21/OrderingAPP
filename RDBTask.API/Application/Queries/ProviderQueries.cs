namespace RDBTask.API.Application.Queries;

using Dapper;
using Microsoft.Data.SqlClient;

public class ProviderQueries : IProviderQueries
{
    private string _connectionString = string.Empty;

    public ProviderQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }

    public async Task<IEnumerable<ProviderResponseModel>> ToListAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            return await connection.QueryAsync<ProviderResponseModel>("SELECT * FROM Providers");
        }
    }
}