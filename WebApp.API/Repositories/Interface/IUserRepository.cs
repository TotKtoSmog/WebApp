using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<User> CreateAsync(User user);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task UpdateAsync(User user);
        public Task<User?> GetUserByIdAsync(int id);
        public Task <IEnumerable<User>> GetAllAsync();
    }
}
