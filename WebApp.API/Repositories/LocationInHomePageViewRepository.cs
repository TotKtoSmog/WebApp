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
        public async Task<LocationInHomePage?> GetLocationByPageNameAsync(string pageName)
        {
            string normalizedPageName = pageName.Trim().ToLowerInvariant();
            await using var context = await _context.CreateDbContextAsync();
            try
            {
                var location = await context.Locations
                    .FirstOrDefaultAsync(n => n.PageName.ToLower() == normalizedPageName);

                if (location == null)
                    _logger.LogWarning("Локация с именем страницы '{PageName}' не найдена.", pageName);

                return location;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении локации по имени страницы: {PageName}", pageName);
                return null;
            }
        }
    }
}
