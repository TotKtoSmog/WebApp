using WebApp.API.Models;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.Platform.ClientAPI;

namespace WebApp.Platform.Areas.Admin.Services
{
    public class AdminFeedbackService : IAdminFeedbackService
    {
        public readonly FeedbackHttpClient _feedbackHttpClient;
        public AdminFeedbackService(FeedbackHttpClient feedbackHttpClient)
        {
            _feedbackHttpClient = feedbackHttpClient;
        }
        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            var feedback = await _feedbackHttpClient.GetAllAsync();
            return feedback.ToList();
        }
    }
}
