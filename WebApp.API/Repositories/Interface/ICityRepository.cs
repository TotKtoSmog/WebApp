using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<IEnumerable<City>> GetVisibleCityAsync();
    }
}
