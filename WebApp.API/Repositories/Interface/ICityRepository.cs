using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllAsync();
        public Task<IEnumerable<City>> GetVisibleCityAsync();
        public Task<City?> GetCityByPageNameAsync(string PageName);
        public Task<City> CreateCityAsync(City city);

    }
}
