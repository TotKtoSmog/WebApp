using WebApp.API.Models;
using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface ICityService
    {
        public Task<City> GetCityByPageNameAsync(string pageName);
        public Task<List<Location>> GetLocationByCityIdAsync(int cityId);
        public Task<List<Location>> GetVisibleLocationAsync(int cityId);
        public Task<AllCityInformation> GetAllCityInformationByPageNameAsync(string pageName);
        public Task<List<Location>> GetVisibleLocationAsync();
    }
}
