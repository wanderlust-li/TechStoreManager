using TechStoreManager.Domain;

namespace TechStoreManager.Application.Services.IServices;

public interface IStoreService
{
    Task<List<Store>> GetAllStore();
}