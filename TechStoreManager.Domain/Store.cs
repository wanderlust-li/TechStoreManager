using TechStoreManager.Domain.Common;

namespace TechStoreManager.Domain;

public class Store : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    // public ICollection<DeviceDTO>? Devices { get; set; } = new List<DeviceDTO>();
}