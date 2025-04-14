using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllAsync();
        public Task<City?> GetAsync(int id);
        public Task<IEnumerable<City>> GetVisibleCityAsync();
        public Task<City?> GetCityByPageNameAsync(string PageName);
        public Task<City> CreateCityAsync(City city);
        public Task UpdateCityAsync(City city);
        public Task DeleteCityAsync(int id);
    }
}
