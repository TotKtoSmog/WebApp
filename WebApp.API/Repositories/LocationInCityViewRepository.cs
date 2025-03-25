using Microsoft.EntityFrameworkCore;
using WebApp.API.Contexts;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class LocationInCityViewRepository : ILocationInCityViewRepository
    {
        private readonly IDbContextFactory<LocationInCityContext> _context;
        private readonly ILogger<LocationInCityViewRepository> _logger;
        public LocationInCityViewRepository(IDbContextFactory<LocationInCityContext> context,
            ILogger<LocationInCityViewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<LocationInCity>> GetLocationInCityByCityIdAsync(int cityId)
            => await _context.CreateDbContext().Locations.Where(n => n.CityId == cityId).ToListAsync();
    }
}
