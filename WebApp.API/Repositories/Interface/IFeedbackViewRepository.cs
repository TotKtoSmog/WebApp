using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface IFeedbackViewRepository
    {
        public Task<IEnumerable<FeedbackView>> GetFeedbackByIdLocationAsync(int idLocation);
        public Task<IEnumerable<FeedbackView>> GetAcceptedFeedbackByIdLocationAsync(int idLocation);
    }
}
