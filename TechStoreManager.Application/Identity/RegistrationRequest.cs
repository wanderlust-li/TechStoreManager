using System.ComponentModel.DataAnnotations;

namespace TechStoreManager.Application.Identity;

public class RegistrationRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}