using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection_Assignment_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesWeatherService _citiesWeatherService;
        public HomeController(ICitiesWeatherService citiesWeatherService)
        {
            _citiesWeatherService = citiesWeatherService;
        }


        [HttpGet]
        [Route("/")]
        public IActionResult Home()
        {
            ViewBag.pageTitle = "Home";
            var cities = _citiesWeatherService.GetAllCities().ToList();
            return View(cities);
        }

        [Route("/weather/{cityCode:length(3, 3)}")]
        public IActionResult CityWeather([FromRoute] string cityCode)
        {
            CityWeatherRequest? cityWeather = _citiesWeatherService.GetCityWeather(cityCode);
            ViewBag.pageTitle = $"{cityWeather?.CityName} Weather";
            return View(cityWeather);
        }

    }
}
