using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ILocationInCityViewRepository
    {
        Task<IEnumerable<LocationInCity>> GetLocationInCityByCityIdAsync(int cityId);
    }
}
