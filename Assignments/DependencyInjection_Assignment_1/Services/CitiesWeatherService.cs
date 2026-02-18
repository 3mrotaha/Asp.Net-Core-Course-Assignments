using Data;
using ServiceContracts;
namespace Services
{
    public class CitiesWeatherService : ICitiesWeatherService
    {
        private readonly Context _context;
        public CitiesWeatherService(Context context) 
        { 
            _context = context;
        }

        public IEnumerable<CityWeatherRequest> GetAllCities()
        {
            List<CityWeatherRequest> req = new List<CityWeatherRequest>();
            foreach (var city in _context.Weathers)
            {
                req.Add(new CityWeatherRequest(city));
            }

            return req;
        }

        CityWeatherRequest? ICitiesWeatherService.GetCityWeather(string cityName)
        {
            return new CityWeatherRequest(_context.Weathers.Where(w => w.CityUniqueCode == cityName).FirstOrDefault());
        }
    }
}
