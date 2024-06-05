using Microsoft.AspNetCore.Mvc;
using TechStoreManager.Application.Identity;
using TechStoreManager.Application.Services.IServices;

namespace TechStoreManager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthRequest authRequest)
    {
        return Ok(await _authService.LoginAsync(authRequest));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest registrationRequest)
    {
        return Ok(await _authService.RegisterAsync(registrationRequest));
    }
}