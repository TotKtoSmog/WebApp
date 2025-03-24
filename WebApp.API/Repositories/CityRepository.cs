using Microsoft.EntityFrameworkCore;
using WebApp.API.Context;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IDbContextFactory<CityContext> _context;
        private readonly ILogger<CityRepository> _logger;
        public CityRepository(IDbContextFactory<CityContext> context, ILogger<CityRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<City>> GetAllAsync()
            => await _context.CreateDbContext().Cities.ToListAsync();

        public async Task<City?> GetCityByPageNameAsync(string PageName)
            => await _context.CreateDbContext().Cities.FirstOrDefaultAsync(n => n.PageName == PageName);

        public async Task<IEnumerable<City>> GetVisibleCityAsync()
            => await _context.CreateDbContext().Cities.Where(n => n.PageVisible).ToListAsync();
    }
}
