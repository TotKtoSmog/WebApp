using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IRecommendationService
    {
        public Task<List<RecommendedItem>> GetRecommendedAsync(RecommendationModel model);
    }
}
