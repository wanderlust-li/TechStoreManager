using Microsoft.AspNetCore.Identity;

namespace TechStoreManager.Domain;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}