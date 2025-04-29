using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IFeedbackRepository
    {
        public Task<Feedback> CreateAsync(Feedback feedback);
        public Task<Feedback?> GetFeedbackAsync(int id);
        public Task UpdateCityAsync(Feedback feedback);
    }
}
