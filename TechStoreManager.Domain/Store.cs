using TechStoreManager.Domain.Common;

namespace TechStoreManager.Domain;

public class Store : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    // public ICollection<Device>? Devices { get; set; } = new List<Device>();
}