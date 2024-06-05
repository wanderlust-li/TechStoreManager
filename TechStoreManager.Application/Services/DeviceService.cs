using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TechStoreManager.Application.Exceptions;
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
            INSERT INTO Devices (Name, Description, Price, StoreId, DateCreated)
            VALUES (@Name, @Description, @Price, @StoreId, GETDATE());
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";
            return await connection.ExecuteAsync(sql, new
            {
                Name = deviceDto.Name,
                Description = deviceDto.Description,
                Price = deviceDto.Price,
                StoreId = deviceDto.StoreId,
                DateCreated = DateTime.Now
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
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var sql = @"
            SELECT d.*, s.*
            FROM Devices d
            LEFT JOIN Stores s ON d.StoreId = s.Id;
        ";
            var devices = await connection.QueryAsync<Device, Store, Device>(sql,
                (device, store) =>
                {
                    device.Store = store;
                    return device;
                },
                splitOn: "Id");

            return devices.ToList();
        }
    }

    public async Task<int> DeleteDeviceById(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var sql = @"
            DELETE FROM Devices
            WHERE Id = @Id;
        ";
            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            
            if (rowsAffected == 0)
                throw new NotFoundException($"DeviceDTO with ID {id} not found.");

            return rowsAffected;
        }
    }

    public async Task<int> UpdateDeviceById(EditDeviceDTO editDeviceDto)
    {
        if (editDeviceDto == null)
            throw new BadRequestException("Device is null");

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            
            var sqlExists = @"
                SELECT COUNT(*)
                FROM Devices
                WHERE Id = @Id;
            ";
            var doesDeviceExist = await connection.QuerySingleAsync<int>(sqlExists, new { Id = editDeviceDto.Id });

            if (doesDeviceExist == 0)
                throw new NotFoundException($"Device with ID {editDeviceDto.Id} not found.");
            
            var sqlUpdate = @"
                UPDATE Devices
                SET Name = @Name, 
                    Description = @Description, 
                    Price = @Price, 
                    StoreId = @StoreId,
                    DateModified = GETUTCDATE() 
                WHERE Id = @Id;
            ";
            var rowsAffected = await connection.ExecuteAsync(sqlUpdate, editDeviceDto);

            return rowsAffected;
        }
    }
}