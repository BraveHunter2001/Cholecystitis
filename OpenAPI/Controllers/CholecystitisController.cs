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
        private readonly ICholecstitisService _cholecstitisService;

        public CholecystitisController(ICholecstitisService cholecstitisService)
        {
            _cholecstitisService = cholecstitisService;
        }

        [HttpPost]
        public IActionResult Create(CholestitsDTO cholecystit)
        {
            var ch = _cholecstitisService.Create(cholecystit);
            return Ok(ch);
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var res = _cholecstitisService.GetCholecystit(id);
            string jsonString = JsonConvert.SerializeObject(res, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Ok(jsonString);
        }

        [HttpPut]
        public IActionResult Update(Cholecystit cholecystit)
        {
            _cholecstitisService.Update(cholecystit);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _cholecstitisService.Delete(id);
            return Ok();
        }
    }
}