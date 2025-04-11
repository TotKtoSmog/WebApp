using WebApp.API.Models;

namespace WebApp.Platform.Areas.Admin.Services.Interfaces
{
    public interface IAdminCityService
    {
        public Task<List<City>> GetAllCityAsync();
    }
}
