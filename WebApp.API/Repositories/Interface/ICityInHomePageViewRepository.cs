using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ICityInHomePageViewRepository
    {
        Task<IEnumerable<CityInHomePage>> GetAllAsync();
        Task<IEnumerable<CityInHomePage>> GetVisibleAsync();
    }
}
