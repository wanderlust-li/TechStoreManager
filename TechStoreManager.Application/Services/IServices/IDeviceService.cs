using TechStoreManager.Application.Models.Device;
using TechStoreManager.Domain;

namespace TechStoreManager.Application.Services.IServices;

public interface IDeviceService
{
    Task<int> AddDeviceAsync(CreateDeviceDTO device);
    Task<Device> GetDeviceByIdAsync(int deviceId);

    Task<List<Device>> GetAllDevice();
}