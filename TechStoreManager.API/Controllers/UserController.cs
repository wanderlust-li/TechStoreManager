using Microsoft.AspNetCore.Mvc;
using TechStoreManager.Application.Services.IServices;
using TechStoreManager.Domain.Identity;

namespace TechStoreManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;

    public UserController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
    {
        return Ok(await _authService.RegisterUserAsync(registrationRequest));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
    {
        return Ok(await _authService.LoginUserAsync(authRequest));
    }
}