using WebApp.API.Models;
using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUserAsync(UserRegistration user);
    }
}
