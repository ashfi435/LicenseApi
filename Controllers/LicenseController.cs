using LicenseApi.Data;
using LicenseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseController(LicenseDbContext context) : ControllerBase
    {
        private readonly LicenseDbContext _context = context;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterDevice([FromBody] DeviceInfo device)
        {
            if (string.IsNullOrWhiteSpace(device.UserId) || string.IsNullOrWhiteSpace(device.DeviceId))
                return BadRequest("Invalid userId or deviceId.");

            var existingDevices = await _context.Devices
                .Where(d => d.UserId == device.UserId)
                .ToListAsync();

            // Jika device sudah terdaftar, skip
            if (existingDevices.Any(d => d.DeviceId == device.DeviceId))
                return Ok("Device already registered.");

            // Maksimum 10 device per userId
            if (existingDevices.Count >= 10)
                return BadRequest("Device limit reached (10).");

            device.RegisteredAt = DateTime.UtcNow;
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return Ok("Device registered successfully.");
        }

        [HttpGet("devices")]
        public async Task<IActionResult> GetDeviceCount([FromQuery] string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest("Missing userId.");

            var count = await _context.Devices
                .CountAsync(d => d.UserId == userId);

            return Ok(new { userId, count });
        }
    }
}
