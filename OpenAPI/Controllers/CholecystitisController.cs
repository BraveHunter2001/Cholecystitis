using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CholecystitisController : ControllerBase
    {
        private readonly ICholecystitsService _cholecystitsService;

        public CholecystitisController(ICholecystitsService cholecystitsService)
        {
            _cholecystitsService = cholecystitsService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CholecystitDTO cholecystit)
        {
            var ch = _cholecystitsService.Create(cholecystit);
            return ch is not null ? Ok($"Cholecystit was successful CREATE with id {ch.Id}") : BadRequest("Error create cholecystit");
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get([FromRoute]Guid id)
        {
            var res = _cholecystitsService.GetCholecystit(id);

            return res is not null ? Ok(res) : BadRequest($"Model didn't found with id = {id}");
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_cholecystitsService.GetAll());
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody]CholecystitDTO cholecystitDto)
        {
           var res =  _cholecystitsService.Update(id, cholecystitDto);
            return res is not null ? Ok($"Cholecystit was successful UPDATE with id {res.Id}") : BadRequest("Model unsuccessful updated");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var res = _cholecystitsService.Delete(id);
            return res is not null ? Ok($"Cholecystit was successful DELETE with id {res.Id}") : BadRequest("Model unsuccessful deleted");
        }


    }
}