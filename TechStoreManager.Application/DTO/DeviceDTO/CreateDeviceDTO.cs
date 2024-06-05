namespace TechStoreManager.Application.Models.Device;

public class CreateDeviceDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int? StoreId { get; set; }
    public DateTime DateCreated { get; set; }
}