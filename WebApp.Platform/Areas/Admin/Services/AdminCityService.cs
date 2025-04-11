using WebApp.API.Models;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.Platform.ClientAPI;

namespace WebApp.Platform.Areas.Admin.Services
{
    public class AdminCityService : IAdminCityService
    {
        private readonly CityHttpClient _cityHttpClient;
        public AdminCityService(CityHttpClient cityHttpClient)
        {
            _cityHttpClient = cityHttpClient;
        }
        public async Task<List<City>> GetAllCityAsync()
        {
            var result = await _cityHttpClient.GetAllAsync();
            return result.ToList();
        }
    }
}
