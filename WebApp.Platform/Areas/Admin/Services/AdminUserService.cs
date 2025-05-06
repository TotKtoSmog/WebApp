using WebApp.API.Models;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.Platform.ClientAPI;

namespace WebApp.Platform.Areas.Admin.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly UserHttpClient _httpClient;
        private readonly ILogger<AdminUserService> _logger;
        public AdminUserService(UserHttpClient userHttpClient, ILogger<AdminUserService> logger)
        {
            _httpClient = userHttpClient;
            _logger = logger;
        }
        public async Task<List<User>> GetAll()
        {
            var result = await _httpClient.GetAllAsync();
            List<User> users = result.ToList();
            _logger.LogInformation("Получен список с пользователями в размере {count}", users.Count);
            return users;
        }
    }
}
