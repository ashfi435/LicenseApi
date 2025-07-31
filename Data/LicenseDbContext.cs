using LicenseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseApi.Data
{
    public class LicenseDbContext : DbContext
    {
        public LicenseDbContext(DbContextOptions<LicenseDbContext> options) : base(options)
        {
        }

        public DbSet<DeviceInfo> Devices { get; set; } = null!;
    }
}