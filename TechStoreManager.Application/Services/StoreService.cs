using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TechStoreManager.Application.Services.IServices;
using TechStoreManager.Domain;

namespace TechStoreManager.Application.Services;

public class StoreService : IStoreService
{
    private readonly string _connectionString;

    public StoreService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task<List<Store>> GetAllStore()
    {
        List<Store> store = new List<Store>();
        using (var connection = new SqlConnection(_connectionString))
        {
            store = (List<Store>)await connection.QueryAsync<Store>(
                @"SELECT * FROM Stores");
        }

        return store;
    }
}