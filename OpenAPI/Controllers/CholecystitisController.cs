using DAL.DTO;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CholecystitisController : ControllerBase
    {
        private readonly ICholecystitsService _cholecystitsService;

        public CholecystitisController(ICholecystitsService cholecystitsService)
        {
            _cholecystitsService = cholecystitsService;
        }

        [HttpPost]
        public IActionResult Create(CholecystitDTO cholecystit)
        {
            var ch = _cholecystitsService.Create(cholecystit);
            return Ok(ch);
        }

        [HttpGet]
        public IActionResult Get([FromQuery]Guid id)
        {
            var res = _cholecystitsService.GetCholecystit(id);

            return Ok(res);
        }

        [HttpPut]
        public IActionResult Update([FromQuery] Guid id, CholecystitDTO cholecystitDto)
        {
            _cholecystitsService.Update(id, cholecystitDto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _cholecystitsService.Delete(id);
            return Ok();
        }
    }
}