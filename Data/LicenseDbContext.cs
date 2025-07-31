using Microsoft.EntityFrameworkCore;
using LicenseApi.Models;

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