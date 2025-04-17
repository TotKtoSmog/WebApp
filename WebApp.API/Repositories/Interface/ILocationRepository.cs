using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ILocationRepository
    {
        public Task<Location?> GetAsync(int id);
    }
}
