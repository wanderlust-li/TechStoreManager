using Microsoft.AspNetCore.Mvc;
using TechStoreManager.Application.Models.Device;
using TechStoreManager.Application.Services.IServices;

namespace TechStoreManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpPost("create-device")]
    public async Task<IActionResult> CreateDevice(CreateDeviceDTO device)
    {
        return Ok(await _deviceService.AddDeviceAsync(device));
    }

    [HttpGet("get-device-by-id")]
    public async Task<IActionResult> GetDeviceById(int deviceId)
    {
        return Ok(await _deviceService.GetDeviceByIdAsync(deviceId));
    }

    [HttpGet("get-all-device")]
    public async Task<IActionResult> GetAllDevice()
    {
        return Ok(await _deviceService.GetAllDevice());
    }

    [HttpDelete("delete-device-by-id")]
    public async Task<IActionResult> DeleteDeviceById(int id)
    {
        return Ok(await _deviceService.DeleteDeviceById(id));
    }

    [HttpPut("update-device-by-id")]
    public async Task<IActionResult> UpdateDeviceById(EditDeviceDTO editDeviceDto)
    {
        return Ok(await _deviceService.UpdateDeviceById(editDeviceDto));
    }
}