using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Context
    {
        public List<CityWeather> Weathers { get; set; }
        public Context()
        {
            Weathers = new List<CityWeather>()
            {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
            };
        }
    }
}
