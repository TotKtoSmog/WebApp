using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.API.Models;

namespace WebApp.Platform.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LocationController : Controller
    {
        
        private readonly IAdminLocationService _locationService;
        private readonly ILogger<LocationController> _logger;

        public LocationController(IAdminLocationService locationService, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Location> locations = await _locationService.GetAllLocationsAsync();
            if(locations.Count < 1) _logger.LogWarning("Получено 0 локаций городов");
            return View(locations);
        }
    }
}
