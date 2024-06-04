using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TechStoreManager.Domain;
using TechStoreManager.Domain.Identity;
using TechStoreManager.Infrastructure.DatabaseContext;

namespace TechStoreManager.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TechStoreDatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<TechStoreDatabaseContext>().AddDefaultTokenProviders();
        
        return services;

    }
}