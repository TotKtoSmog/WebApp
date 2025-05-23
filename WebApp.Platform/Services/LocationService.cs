using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Models;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class LocationService : ILocationService, ILocationByUser
    {
        private readonly LocationHttpClient _locationHttpClient;
        private readonly LocationViewHttpClient _locationViewHttpClient;
        private readonly LocationGalleryHttpClient _locationGalleryHttpClient;
        private readonly FeedbackViewHttpClient _feedbackViewHttpClient;
        private readonly FeedbackHttpClient _feedbackHttpClient;
        private readonly IClientIpService _clientIpService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IFavoriteLocationService _favoriteLocationService;
        public LocationService(LocationViewHttpClient locationViewHttpClient, 
            LocationHttpClient locationHttpClient, 
            LocationGalleryHttpClient locationGalleryHttpClient,
            FeedbackViewHttpClient feedbackViewHttpClient,
            FeedbackHttpClient feedbackHttpClient,
            IClientIpService clientIpService, IJwtTokenService jwtTokenService, 
            IFavoriteLocationService favoriteLocationService)
        {
            _locationViewHttpClient = locationViewHttpClient;
            _locationHttpClient = locationHttpClient;
            _locationGalleryHttpClient = locationGalleryHttpClient;
            _feedbackViewHttpClient = feedbackViewHttpClient;
            _feedbackHttpClient = feedbackHttpClient;
            _clientIpService = clientIpService;
            _jwtTokenService = jwtTokenService;
            _favoriteLocationService = favoriteLocationService;
        }

        public async Task ChangeFavoriteLocation(string pageName, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var id = _jwtTokenService.GetUserIdFromToken(token);
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int userId))
                {
                    LocationInHomePage location = await GetLocationInHomePageByPageNameAsync(pageName);
                    List<FavoriteLocation> fl = await _favoriteLocationService.GetByUserIdAsync(userId);

                    FavoriteLocation? f = fl.FirstOrDefault(f => f.IdLocation == location.Id);

                    if (f != null) await _favoriteLocationService.DeleteAsync(f.Id);
                    else await _favoriteLocationService.CreateAsync(new FavoriteLocation { Id = 0, IdLocation = location.Id, IdUser = userId });
                }
            }
        }

        public async Task<Feedback> CreateFeedbackAsync(Feedback feedback)
        {
            feedback.SenderIpAddress = _clientIpService.GetClientIp();
            feedback.DateTime = DateTime.UtcNow;
            return await _feedbackHttpClient.CreateFeedbackAsync(feedback);
        }

        public async Task<Feedback> CreateFeedbackAsync(Feedback feedback, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var id = _jwtTokenService.GetUserIdFromToken(token);
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int userId))
                    feedback.IdUser = userId;
            }
            return await CreateFeedbackAsync(feedback);
        }

        public async Task<List<Location>> GetAllAsync()
        {
            var location = await _locationHttpClient.GetVisibleAsync();
            return location.ToList();
        }

        public async Task<AllLocationInformation> GetAllLocationInformationAsync(string pageName, string token)
        {
            LocationInHomePage location = await GetLocationInHomePageByPageNameAsync(pageName);
            List<LocationGallery> gallery = await GetLocationGalleryByIdLocationAsync(location.Id);
            List<FeedbackView> feedbacks = await GetFeedbackViewByIdLocationAsync(location.Id);
            bool IsFavorite = false;
            if (!string.IsNullOrEmpty(token))
            {
                var id = _jwtTokenService.GetUserIdFromToken(token);
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int userId))
                {
                    List<FavoriteLocation> fl = await _favoriteLocationService.GetByUserIdAsync(userId);
                    if(fl.Where(l=> l.IdLocation == location.Id).Any()) IsFavorite = true;
                }
            }
            return new AllLocationInformation(location, gallery, feedbacks, IsFavorite);
        }

        public async Task<Location?> GetAsync(int idLocation)
            => await _locationHttpClient.GetAsync(idLocation);

        public async Task<List<FeedbackView>> GetFeedbackViewByIdLocationAsync(int idLocation)
        {
            var result = await _feedbackViewHttpClient.GetFeedbackByIdLocationAsync(idLocation, true);
            return result.ToList();
        }

        public async Task<List<LocationGallery>> GetLocationGalleryByIdLocationAsync(int idLocation)
        {
            var result = await _locationGalleryHttpClient.GetLocationGalleryByIdLocationAsync(idLocation);
            return result.ToList();
        }
            
        public async Task<LocationInHomePage> GetLocationInHomePageByPageNameAsync(string pageName)
            => await _locationViewHttpClient.GetLocationByPageNameAsync(pageName);

        public string? GetUserFirstAndLastName(string token)
            => (!string.IsNullOrEmpty(token)) ? _jwtTokenService.GetNameUserFromToken(token) : null;
    }
}
