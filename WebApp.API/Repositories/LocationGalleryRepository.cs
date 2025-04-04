using Microsoft.EntityFrameworkCore;
using WebApp.API.Contexts;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class LocationGalleryRepository : ILocationGalleryRepository
    {
        private readonly IDbContextFactory<LocationGalleryContext> _context;
        private readonly ILogger<LocationGalleryRepository> _logger;

        public LocationGalleryRepository(IDbContextFactory<LocationGalleryContext> context,
            ILogger<LocationGalleryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<LocationGallery>> GetGalleryByIdLocationAsync(int locationId)
        {
            if (locationId <= 0)
            {
                _logger.LogWarning("Передан некорректный locationId: {LocationId}", locationId);
                return Enumerable.Empty<LocationGallery>();
            }

            await using var context = await _context.CreateDbContextAsync();

            try
            {
                var galleryItems = await context.Gallery
                    .Where(n => n.LocationId == locationId)
                    .OrderBy(n => n.Id)
                    .ToListAsync();

                if (!galleryItems.Any())
                    _logger.LogInformation("Галерея для локации с id {LocationId} не найдена.", locationId);

                return galleryItems;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении галереи для локации с id {LocationId}", locationId);
                return Enumerable.Empty<LocationGallery>();
            }
        }
    }
}
