using Microsoft.EntityFrameworkCore;
using WebApp.API.Contexts;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<UserContext> _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IDbContextFactory<UserContext> context, 
            ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> CreateAsync(User user)
        {
            var context = await _context.CreateDbContextAsync();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
