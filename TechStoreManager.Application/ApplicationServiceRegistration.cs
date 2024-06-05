using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechStoreManager.Application.Services;
using TechStoreManager.Application.Services.IServices;

namespace TechStoreManager.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}