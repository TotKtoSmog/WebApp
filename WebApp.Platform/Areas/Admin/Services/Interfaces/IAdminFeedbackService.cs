using WebApp.API.Models;

namespace WebApp.Platform.Areas.Admin.Services.Interfaces
{
    public interface IAdminFeedbackService
    {
        public Task<List<Feedback>> GetFeedbacksAsync();
    }
}
