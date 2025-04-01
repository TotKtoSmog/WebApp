using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<User> CreateAsync(User user);
    }
}
