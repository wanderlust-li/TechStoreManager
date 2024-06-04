using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechStoreManager.Domain;

namespace TechStoreManager.Infrastructure.DatabaseContext;

public class TechStoreDatabaseContext : DbContext
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