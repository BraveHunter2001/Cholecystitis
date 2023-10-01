using DAL.Model;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Services;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BacteriumController : ControllerBase
    {
        private BacteriumService _bacteriumService;

        public BacteriumController(BacteriumService bacteriumService)
        {
            _bacteriumService = bacteriumService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_bacteriumService.GetNamesAllBacterium());

        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            _bacteriumService.AddNew(name);
            return Ok(name);
        }
    }
}