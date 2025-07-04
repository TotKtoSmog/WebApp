﻿using WebApp.API.Models;
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

        public async Task AcceptedFeedbacksAsync(int id)
            => await _feedbackHttpClient.AcceptedFeedbackAsync(id);

        public async Task DeleteFeedbackAsync(int id)
            => await _feedbackHttpClient.DeleteFeedbackAsync(id);

        public async Task<Feedback?> GetFeedbackByIdAsync(int id)
            => await _feedbackHttpClient.GetAsync(id);

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            var feedback = await _feedbackHttpClient.GetAllAsync();
            return feedback.ToList();
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
            => await _feedbackHttpClient.UpdateFeedbackAsync(feedback);
    }
}
