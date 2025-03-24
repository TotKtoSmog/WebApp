using Microsoft.EntityFrameworkCore;
using WebApp.API.Contexts;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class CityInHomePageViewRepository : ICityInHomePageViewRepository
    {

        private readonly IDbContextFactory<CityInHomePageContext> _context;
        private readonly ILogger<CityInHomePageViewRepository> _logger;
        public CityInHomePageViewRepository(IDbContextFactory<CityInHomePageContext> context, 
            ILogger<CityInHomePageViewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<CityInHomePage>> GetAllAsync()
            => await _context.CreateDbContext().Cities.ToListAsync();
    }
}
