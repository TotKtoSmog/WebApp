using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Models;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class CityService : ICityService
    {
        private readonly CityHttpClient _cityHttpClient;
        private readonly LocationViewHttpClient _locationViewHttpClient;
        private readonly LocationHttpClient _locationHttpClient;
        public CityService(CityHttpClient cityHttpClient, LocationViewHttpClient locationViewHttpClient, LocationHttpClient locationHttpClient)
        {
            _cityHttpClient = cityHttpClient;
            _locationViewHttpClient = locationViewHttpClient;
            _locationHttpClient = locationHttpClient;
        }
        public async Task<AllCityInformation> GetAllCityInformationByPageNameAsync(string pageName)
        {
            City city = await GetCityByPageNameAsync(pageName);
            List<Location> locations = await GetVisibleLocationAsync(city.Id);
            return new AllCityInformation(city, locations);
        }
        public async Task<City> GetCityByPageNameAsync(string pageName)
            => await _cityHttpClient.GetCityByPageNameAsync(pageName);

        public async Task<List<Location>> GetLocationByCityIdAsync(int cityId)
        {
            var result = await _locationHttpClient.GetLocationByCityIdAsync(cityId);
            return result.ToList();
        }

        public async Task<List<LocationInCity>> GetLocationInCityByCityIdAsync(int cityId)
        {
            var result = await _locationViewHttpClient.GetLocationInCitiesByCityIdAsync(cityId);
            return result.ToList();
        }

        public async Task<List<Location>> GetVisibleLocationAsync(int cityId)
        {
            var result = await _locationHttpClient.GetVisibleLocationByCityIdAsync(cityId);
            return result.ToList();
        }
    }
}
