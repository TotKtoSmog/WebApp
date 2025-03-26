using WebApp.API.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<LocationInHomePage> GetLocationInHomePageByPageNameAsync(string pageName);
    }
}
