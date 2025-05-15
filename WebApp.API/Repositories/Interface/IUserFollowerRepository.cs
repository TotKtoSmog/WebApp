using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IUserFollowerRepository
    {
        public Task<UserFollower?> GetAsync(int id);
        public Task<List<UserFollower>> GetAllAsync();
        public Task<List<UserFollower>> GetByUserIdAsync(int idUser);
        public Task<List<UserFollower>> GetByFollowerIdAsync(int idFollower);
        public Task<UserFollower> CreateAsync(UserFollower userFollower);
        public Task DeleteAsync(int id);
    }
}
