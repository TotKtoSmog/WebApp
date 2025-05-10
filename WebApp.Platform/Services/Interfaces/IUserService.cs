using WebApp.API.Models;
using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> RegistrationUserAsync(UserRegistration user);
        public Task<string?> AuthorizationUserAsync(UserAuthorization user);
        public Task<User> CreateUserAsync(UserRegistration user);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task UpdateUserAsync(User user);
        public Task<User?> GetUserByTokenAsync(string token);
        public Task<List<Feedback>> GetUserFeedback(int id);
    }
}
