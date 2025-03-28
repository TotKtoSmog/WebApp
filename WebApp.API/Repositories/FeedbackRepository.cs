using Microsoft.EntityFrameworkCore;
using WebApp.API.Context;
using WebApp.API.Contexts;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IDbContextFactory<FeedbackContext> _context;
        private readonly ILogger<FeedbackRepository> _logger;
        public FeedbackRepository(IDbContextFactory<FeedbackContext> context, ILogger<FeedbackRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Feedback> CreateAsync(Feedback feedback)
        {
            var context = await _context.CreateDbContextAsync();
            await context.Feedbacks.AddAsync(feedback);
            await context.SaveChangesAsync();
            return feedback;
        }
    }
}
