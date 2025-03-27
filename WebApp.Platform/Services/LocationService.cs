using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Models;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class LocationService : ILocationService
    {
        private readonly LocationViewHttpClient _locationViewHttpClient;
        private readonly LocationGalleryHttpClient _locationGalleryHttpClient;
        public LocationService(LocationViewHttpClient locationViewHttpClient, 
            LocationGalleryHttpClient locationGalleryHttpClient)
        {
            _locationViewHttpClient = locationViewHttpClient;
            _locationGalleryHttpClient = locationGalleryHttpClient;
        }

        public async Task<AllLocationInformation> GetAllLocationInformationAsync(string pageName)
        {
            LocationInHomePage location = await GetLocationInHomePageByPageNameAsync(pageName);
            List<LocationGallery> gallery = await GetLocationGalleryByPageNameAsync(location.Id);
            return new AllLocationInformation(location, gallery);
        }

        public async Task<List<LocationGallery>> GetLocationGalleryByPageNameAsync(int id)
        {
            var result = await _locationGalleryHttpClient.GetLocationGalleryByLocationIdAsync(id);
            return result.ToList();
        }
            
        public async Task<LocationInHomePage> GetLocationInHomePageByPageNameAsync(string pageName)
            => await _locationViewHttpClient.GetLocationByPageNameAsync(pageName); 
    }
}
