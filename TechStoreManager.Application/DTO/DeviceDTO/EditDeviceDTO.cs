namespace TechStoreManager.Application.Models.Device;

public class EditDeviceDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int? StoreId { get; set; }
}