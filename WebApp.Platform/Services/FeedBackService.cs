using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class FeedBackService: IFeedBackUser
    {
        private readonly FeedbackHttpClient _httpClient;

        public FeedBackService(FeedbackHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Feedback>> GetFeedbackByUserId(int UserId)
        {
            var Feedback = await _httpClient.GetAllAsync();
            return Feedback.Where(f => f.IdUser == UserId).ToList();
        }
    }
}
