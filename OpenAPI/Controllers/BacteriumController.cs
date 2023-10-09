using Microsoft.AspNetCore.Mvc;
using Services;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BacteriumController : ControllerBase
    {
        private readonly IBacteriumService _bacteriumService;

        public BacteriumController(IBacteriumService bacteriumService)
        {
            _bacteriumService = bacteriumService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_bacteriumService.GetAllBacterium());

        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            _bacteriumService.AddNew(name);
            return Ok(name);
        }
    }
}