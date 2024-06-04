using TechStoreManager.Domain;

namespace TechStoreManager.Application.Services.IServices;

public interface IDeviceService
{
    Task CreateDevice(Store store);
}