using WebApp.API.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IUserFollowerService
    {
        public Task<UserFollower> GetAsync(int id);
        public Task<List<UserFollower>> GetByUserIdAsync(int id);
        public Task<UserFollower> CreateAsync(UserFollower Follower);
        public Task DeleteAsync(int id);
    }
}
