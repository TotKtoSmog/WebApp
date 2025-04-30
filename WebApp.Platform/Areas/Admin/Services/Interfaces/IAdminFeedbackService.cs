using WebApp.API.Models;

namespace WebApp.Platform.Areas.Admin.Services.Interfaces
{
    public interface IAdminFeedbackService
    {
        public Task<List<Feedback>> GetFeedbacksAsync();
        public Task AcceptedFeedbacksAsync(int id);
        public Task DeleteFeedbackAsync(int id);
        public Task<Feedback?> GetFeedbackByIdAsync(int id);
        public Task UpdateFeedbackAsync(Feedback feedback);
    }
}
