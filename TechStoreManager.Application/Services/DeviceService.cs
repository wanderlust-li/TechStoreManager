using Microsoft.Extensions.Configuration;
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
    
    public async Task CreateDevice(Store store)
    {
        throw new NotImplementedException();
    }
}