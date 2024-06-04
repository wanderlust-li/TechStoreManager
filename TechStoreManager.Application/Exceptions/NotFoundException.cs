namespace TechStoreManager.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(object name) : base($"{name} was not found")
    {
            
    }
}