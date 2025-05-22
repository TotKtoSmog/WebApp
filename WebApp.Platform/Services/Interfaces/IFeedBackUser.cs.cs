using WebApp.API.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IFeedBackUser
    {
        public Task<List<Feedback>> GetFeedbackByUserId(int UserId);
    }
}
