using Microsoft.AspNetCore.Mvc;
using WebApp.API.Models;
using WebApp.API.Repositories.Interface;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _repository;
        private readonly ILogger<CityController> _logger;
        public CityController(ICityRepository repository, ILogger<CityController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<City>>> GetAllAsync() => Ok(await _repository.GetAllAsync());
        [HttpGet("GetVisibleCity")]
        public async Task<ActionResult<IEnumerable<City>>> GetVisibleCityAsync() => Ok(await _repository.GetVisibleCityAsync());
    }
}
