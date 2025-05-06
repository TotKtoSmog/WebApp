using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.Models;
using WebApp.Platform.Areas.Admin.Services.Interfaces;

namespace WebApp.Platform.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAdminUserService _adminUserService;
        private readonly ILogger<UserController> _logger;
        public UserController(IAdminUserService adminUserService, ILogger<UserController> logger)
        {
            _adminUserService = adminUserService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<User> users = await _adminUserService.GetAll();
            _logger.LogInformation("Список пользователей сформирован для отображения");

            return View(users);
        }
    }
}
