using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMate.Extensions
{
    class WeatherResponse
    {
        public Feels_like feels_Like { get; set; }
        public WindInfo wind { get; set; }
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }
    }
}
