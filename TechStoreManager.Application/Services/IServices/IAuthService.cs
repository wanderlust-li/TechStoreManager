using TechStoreManager.Domain.Identity;

namespace TechStoreManager.Application.Services.IServices;

public interface IAuthService
{
    Task<RegistrationResponse> RegisterUserAsync(RegistrationRequest registrationRequest);
    Task<AuthResponse> LoginUserAsync(AuthRequest authRequest);
}