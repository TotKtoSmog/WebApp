using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ILocationInHomePageViewRepository
    {
        public Task<LocationInHomePage?> GetLocationByPageNameAsync(string pageName);
    }
}
