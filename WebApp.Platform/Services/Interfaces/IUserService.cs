﻿using WebApp.API.Models;
using WebApp.Platform.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> RegistrationUserAsync(UserRegistration user);
        public Task<string?> AuthorizationUserAsync(UserAuthorization user);
        public Task<User> CreateUserAsync(UserRegistration user);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task UpdateUserAsync(User user);
        public Task<User?> GetUserByTokenAsync(string token);
        public Task<List<UserFeedback>> GetUserFeedbackAsync(int id);
        public Task<List<FavoriteLocationItem>> GetFavoriteLocationsAsync(int id);
        public Task<List<User>> GetAllAsync();
        public Task<List<Follower>> GetUserSubscriptionsAsync(int id);
        public Task<List<Follower>> GetUserFollowersAsync(int id);
        public Task<User?> GetAsync(int id);
        public Task<List<RecommendedItem>> GetUserRecommendation(int id);
    }
}
