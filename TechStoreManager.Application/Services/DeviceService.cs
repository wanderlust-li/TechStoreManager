using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TechStoreManager.Application.Models.Device;
using TechStoreManager.Application.Services.IServices;
using TechStoreManager.Domain;

namespace TechStoreManager.Application.Services;

public class DeviceService : IDeviceService
{
    private readonly string _connectionString;

    public DeviceService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task<int> AddDeviceAsync(CreateDeviceDTO deviceDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var sql = @"
                INSERT INTO Devices (Name, Description, Price, StoreId)
                VALUES (@Name, @Description, @Price, @StoreId);
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";
            return await connection.ExecuteAsync(sql, new
            {
                Name = deviceDto.Name,
                Description = deviceDto.Description,
                Price = deviceDto.Price,
                StoreId = deviceDto.StoreId
            });
        }
    }
    
    public async Task<Device> GetDeviceByIdAsync(int deviceId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var sql = @"
                SELECT d.*, s.*
                FROM Devices d
                LEFT JOIN Stores s ON d.StoreId = s.Id
                WHERE d.Id = @Id;
            ";
            var device = await connection.QueryAsync<Device, Store, Device>(sql,
                (device, store) =>
                {
                    device.Store = store;
                    return device;
                },
                new { Id = deviceId },
                splitOn: "Id");
            
            return device.FirstOrDefault();
        }
    }

    public async Task<List<Device>> GetAllDevice()
    {
        throw new NotImplementedException();
    }
}