using Microsoft.AspNetCore.Mvc;
using TechStoreManager.Application.DTO.StoreDTO;
using TechStoreManager.Application.Services.IServices;

namespace TechStoreManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : Controller
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet("get-all-store")]
    public async Task<IActionResult> GetAllStore()
    {
        return Ok(await _storeService.GetAllStore());
    }

    [HttpPost("create-store")]
    public async Task<IActionResult> CreateStore(CreateStoreDTO createStoreDto)
    {
        return Ok(await _storeService.CreateStore(createStoreDto));
    }
}