using WebApp.API.Models;
using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<LocationInHomePage> GetLocationInHomePageByPageNameAsync(string pageName);
        public Task<List<LocationGallery>> GetLocationGalleryByIdLocationAsync(int idLocation);
        public Task<List<FeedbackView>> GetFeedbackViewByIdLocationAsync(int idLocation);
        public Task<AllLocationInformation> GetAllLocationInformationAsync(string pageName);
        public Task<Feedback> CreateFeedbackAsync(Feedback feedback);
        public Task<Feedback> CreateFeedbackAsync(Feedback feedback, string token);
        public string? GetUserFirstAndLastName(string token);
    }
}
