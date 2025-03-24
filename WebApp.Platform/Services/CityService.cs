using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class CityService : ICityService
    {
        private readonly CityHttpClient _cityHttpClient;
        public CityService(CityHttpClient cityHttpClient)
        {
            _cityHttpClient = cityHttpClient;
        }
        public async Task<City> GetCityByPageNameAsync(string pageName)
            => await _cityHttpClient.GetCityByPageNameAsync(pageName);
    }
}
