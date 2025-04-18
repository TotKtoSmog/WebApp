using WebApp.API.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IHomeService
    {
        public Task<List<CityInHomePage>> GetAllCityAsync();
        public Task<List<CityInHomePage>> GetVisibleCityAsync();
    }
}
