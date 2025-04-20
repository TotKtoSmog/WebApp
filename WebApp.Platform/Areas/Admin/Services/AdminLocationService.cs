using WebApp.API.Models;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.Platform.ClientAPI;

namespace WebApp.Platform.Areas.Admin.Services
{
    public class AdminLocationService : IAdminLocationService
    {
        private readonly LocationHttpClient _locationHttpClient;
        public AdminLocationService(LocationHttpClient locationHttpClient)
        {
            _locationHttpClient = locationHttpClient;
        }
        public async Task<List<Location>> GetAllLocationsAsync()
        {
            var locations = await _locationHttpClient.GetAllAsync();
            return locations.ToList();
        }
    }
}
