using WebApp.API.Models;
using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<LocationInHomePage> GetLocationInHomePageByPageNameAsync(string pageName);
        public Task<List<LocationGallery>> GetLocationGalleryByPageNameAsync(int id);
        public Task<AllLocationInformation> GetAllLocationInformationAsync(string pageName);
    }
}
