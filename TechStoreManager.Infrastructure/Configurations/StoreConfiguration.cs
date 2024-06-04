using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStoreManager.Domain;

namespace TechStoreManager.Infrastructure.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasData(
            new Store
            {
                Id = 1,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Rozetka",
                Location = "Kyiv"
            },
            new Store
            {
                Id = 2,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Name = "Hotline",
                Location = "Lviv"
            }
        );
    }
}