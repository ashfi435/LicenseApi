﻿using System.ComponentModel.DataAnnotations;

namespace LicenseApi.Models
{
    public class DeviceInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string DeviceId { get; set; } = string.Empty;

        public string DeviceName { get; set; } = string.Empty;

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}