using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IFeedbackRepository
    {
        public Task<Feedback> CreateAsync(Feedback feedback);
        public Task<Feedback?> GetFeedbackAsync(int id);
        public Task UpdateFeedbackAsync(Feedback feedback);
        public Task AcceptedFeedbackAsync(int id);
        public Task DeleteFeedbackAsync(int id);
        public Task <IEnumerable<Feedback>> GetAllAsync();
    }
}
