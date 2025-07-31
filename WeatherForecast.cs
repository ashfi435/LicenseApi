using System;

namespace LicenseApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; } // Ganti dari DateOnly
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}