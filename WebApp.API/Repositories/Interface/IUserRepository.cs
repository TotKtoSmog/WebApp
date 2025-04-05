using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<User> CreateAsync(User user);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task<User?> GetUserByEmailAndHashPassAsync(string email, string hashPassword);
    }
}
