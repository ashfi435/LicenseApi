using System;
using System.ComponentModel.DataAnnotations;

namespace LicenseApi.Models
{
    public class DeviceInfo
    {
        public int Id { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? DeviceId { get; set; }

        public string? DeviceName { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}