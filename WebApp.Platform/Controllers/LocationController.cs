using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.API.Models;
using WebApp.Platform.Models;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;
        private readonly IClientIpService _clientIpService;

        public LocationController(ILogger<LocationController> logger, ILocationService cityService, 
            IClientIpService clientIpService)
        {
            _logger = logger;
            _locationService = cityService;
            _clientIpService = clientIpService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string pageName)
        {
            AllLocationInformation locationInformation = await _locationService.GetAllLocationInformationAsync(pageName);
            
            if(locationInformation == null) 
                return NotFound();

            return View(locationInformation);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(string pageName, Feedback model)
        {
            model.SenderIpAddress = _clientIpService.GetClientIp();
            model.DateTime = DateTime.UtcNow;

            await _locationService.CreateFeedbackAsync(model);
            return RedirectToAction("Index", new { pageName });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
