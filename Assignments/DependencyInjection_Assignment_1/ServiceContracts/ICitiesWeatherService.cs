using Data;
namespace ServiceContracts
{
    public interface ICitiesWeatherService
    {
        public CityWeatherRequest? GetCityWeather(string cityName);

        public IEnumerable<CityWeatherRequest> GetAllCities();
    }
}
