using LicenseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseApi.Data
{
    public class LicenseDbContext(DbContextOptions<LicenseDbContext> options) : DbContext(options)
    {
        public DbSet<DeviceInfo> Devices { get; set; } = null!;
    }
}
