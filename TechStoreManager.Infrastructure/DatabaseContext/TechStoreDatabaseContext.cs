using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechStoreManager.Domain;
using TechStoreManager.Domain.EntityUser;

namespace TechStoreManager.Infrastructure.DatabaseContext;

public class TechStoreDatabaseContext : IdentityDbContext<User>
{
    public TechStoreDatabaseContext(DbContextOptions<TechStoreDatabaseContext> options) : base(options) {}
    
    public DbSet<Device> Devices { get; set; }
    public DbSet<Store> Stores { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TechStoreDatabaseContext).Assembly);
    }
}