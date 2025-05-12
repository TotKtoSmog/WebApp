using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IFavoriteLocationRepository
    {
        public Task<FavoriteLocation> GetAsync(int id);
        public Task<IEnumerable<FavoriteLocation>> GetAllAsync();
        public Task<IEnumerable<FavoriteLocation>> GetByUserIdAsync(int idUser);
        public Task<FavoriteLocation> CreateAsync(FavoriteLocation favoriteLocation);
        public Task DeleteAsync(int id);
    }
}
