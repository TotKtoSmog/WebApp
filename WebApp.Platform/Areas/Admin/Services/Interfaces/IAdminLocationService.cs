using WebApp.API.Models;

namespace WebApp.Platform.Areas.Admin.Services.Interfaces
{
    public interface IAdminLocationService
    {
        public Task<List<Location>> GetAllLocationsAsync();
    }
}
