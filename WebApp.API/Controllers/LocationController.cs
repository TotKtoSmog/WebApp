using Microsoft.AspNetCore.Mvc;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationInCityViewRepository _repositoryLocationInCity;
        public readonly ILocationInHomePageViewRepository _repositoryLocationInHomePage;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationInCityViewRepository locationInCityRepository,
            ILocationInHomePageViewRepository locationInHomePageRepository, ILogger<LocationController> logger)
        {
            _repositoryLocationInCity = locationInCityRepository;
            _repositoryLocationInHomePage = locationInHomePageRepository;
            _logger = logger;
        }

        [HttpGet("GetLocationsByCityId")]
        public async Task<ActionResult<IEnumerable<LocationInCity>>> GetLocationsByCityIdAsync(int cityId)
           => Ok(await _repositoryLocationInCity.GetLocationInCityByCityIdAsync(cityId));
        [HttpGet("GetLocationByPageName")]
        public async Task<ActionResult<LocationInHomePage>> GetLocationByPageNameAsync(string pageName) 
            => Ok(await _repositoryLocationInHomePage.GetLocationByPageNameAsync(pageName));
    }
}
