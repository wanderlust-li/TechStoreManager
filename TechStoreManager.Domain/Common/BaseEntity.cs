namespace TechStoreManager.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now;
    
    public DateTime? DateModified { get; set; }
}