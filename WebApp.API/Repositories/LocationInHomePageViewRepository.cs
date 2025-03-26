using Microsoft.EntityFrameworkCore;
using WebApp.API.Contexts;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class LocationInHomePageViewRepository
        : ILocationInHomePageViewRepository
    {
        private readonly IDbContextFactory<LocationInHomePageContext> _context;
        private readonly ILogger<LocationInHomePageViewRepository> _logger;
        public LocationInHomePageViewRepository(IDbContextFactory<LocationInHomePageContext> context,
            ILogger<LocationInHomePageViewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<LocationInHomePage> GetLocationByPageNameAsync(string pageName)
            => await _context.CreateDbContext().Locations.FirstAsync(n => n.PageName == pageName);
    }
}
