using Microsoft.AspNetCore.Mvc;
using RazorViews_Assignment_1.Models;

namespace RazorViews_Assignment_1.Controllers
{
    public class WeatherController : Controller
    {
        private List<CityWeather> cities = new List<CityWeather>()
        {
            new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
            new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82},
            new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
        };

        [Route("/")]
        public IActionResult Home()
        {
            ViewBag.pageTitle = "Home";
            return View("HomeView", cities);
        }

        [Route("/weather/{cityCode:length(3, 3)}")]
        public IActionResult CityWeather([FromRoute] string cityCode)
        {
            CityWeather? cityWeather = cities.Where(c => c.CityUniqueCode == cityCode).FirstOrDefault();
            ViewBag.pageTitle = $"{cityWeather?.CityName} Weather";
            return View("CityWeatherView", cityWeather);
        }
    }
}
