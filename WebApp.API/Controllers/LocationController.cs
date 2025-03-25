using Microsoft.AspNetCore.Mvc;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationInCityViewRepository _repository;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationInCityViewRepository locationInCityRepository, 
            ILogger<LocationController> logger)
        {
            _repository = locationInCityRepository;
            _logger = logger;
        }

        [HttpGet("GetLocationsByCityId")]
        public async Task<ActionResult<IEnumerable<LocationInCity>>> GetLocationsByCityIdAsync(int cityId)
           => Ok(await _repository.GetLocationInCityByCityIdAsync(cityId));
    }
}
