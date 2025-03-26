using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class LocationService : ILocationService
    {
        private readonly LocationViewHttpClient _locationViewHttpClient;
        public LocationService(LocationViewHttpClient locationViewHttpClient)
        {
            _locationViewHttpClient = locationViewHttpClient;
        }
        public async Task<LocationInHomePage> GetLocationInHomePageByPageNameAsync(string pageName)
            => await _locationViewHttpClient.GetLocationByPageNameAsync(pageName);
    }
}
