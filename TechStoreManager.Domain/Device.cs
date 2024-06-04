using TechStoreManager.Domain.Common;

namespace TechStoreManager.Domain;

public class Device : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int? StoreId { get; set; }
    public Store? Store { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}