using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public class CityWeatherRequest
    {
        public CityWeatherRequest(CityWeather cityWeather)
        {
            CityUniqueCode = cityWeather.CityUniqueCode;
            CityName = cityWeather.CityName;
            DateAndTime = cityWeather.DateAndTime;
            TemperatureFahrenheit = cityWeather.TemperatureFahrenheit;
        }

        public string CityUniqueCode { get; set; }
        public string CityName { get; set; }
        public DateTime DateAndTime { get; set; }
        public int TemperatureFahrenheit { get; set; }
    }
}
