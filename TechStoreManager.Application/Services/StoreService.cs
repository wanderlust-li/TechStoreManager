using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TechStoreManager.Application.DTO.StoreDTO;
using TechStoreManager.Application.Exceptions;
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
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var sql = @"
            SELECT *
            FROM Stores;
        ";
            var stores = await connection.QueryAsync<Store>(sql);
            return stores.ToList();
        }
    }


    public async Task<int> CreateStore(CreateStoreDTO createStoreDto)
    {
        if (createStoreDto == null)
            throw new BadRequestException("Store is null");
        
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            
            var sqlExists = @"
            SELECT COUNT(*)
            FROM Stores
            WHERE Name = @Name;
        ";
            var storeExists = await connection.QuerySingleAsync<int>(sqlExists, new { Name = createStoreDto.Name });

            if (storeExists > 0)
                throw new BadRequestException("Store with the same name already exists.");
            
            var sqlInsert = @"
            INSERT INTO Stores (Name, Location)
            VALUES (@Name, @Location);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";
            return await connection.ExecuteAsync(sqlInsert, new
            {
                Name = createStoreDto.Name,
                Location = createStoreDto.Location
            });
        }
    }

}