using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.API.Models;
using WebApp.Platform.Models;
using WebApp.Platform.Services;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger, ILocationService cityService)
        {
            _logger = logger;
            _locationService = cityService;
        }
        public async Task<IActionResult> Index(string pageName)
        {
            AllLocationInformation locationInformation = await _locationService.GetAllLocationInformationAsync(pageName);
            
            if(locationInformation == null) 
                return NotFound();

            return View(locationInformation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
