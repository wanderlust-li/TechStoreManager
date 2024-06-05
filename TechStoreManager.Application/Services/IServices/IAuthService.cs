using TechStoreManager.Application.Identity;

namespace TechStoreManager.Application.Services.IServices;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(AuthRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
}