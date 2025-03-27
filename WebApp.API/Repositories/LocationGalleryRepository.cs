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
            => await _context.CreateDbContext().Gallery.Where(n => n.LocationId == locationId)
            .OrderBy(n => n.Id).ToListAsync();
    }
}
