using WebApp.API.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface ICityService
    {
        public Task<City> GetCityByPageNameAsync(string pageName);
    }
}
