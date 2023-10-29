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
        private readonly ILocalizationService _localization;
        private readonly IHATEOASService _HATEOASService;

        public CholecystitisController(ICholecystitsService cholecystitsService, ILocalizationService localization, IHATEOASService HATEOASService)
        {
            _cholecystitsService = cholecystitsService;
            _localization = localization;
            _HATEOASService = HATEOASService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CholecystitDTO cholecystit)
        {
            var ch = _cholecystitsService.Create(cholecystit);

            var lang = Request.Headers.AcceptLanguage.ToString(); 

            return ch is not null ? Ok($"{_localization.Localize("SuccessfulCreate", lang)} {ch.Id}") :
                BadRequest(_localization.Localize("BadCreate", lang));
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get([FromRoute]Guid id)
        {
            var res = _cholecystitsService.GetCholecystit(id);

            var lang = Request.Headers.AcceptLanguage.ToString();

            var wrap = _HATEOASService.BuildHATEOASGet(res, lang);

            return res is not null ? Ok(wrap) : BadRequest($"{_localization.Localize("BadGet", lang)} {id}");
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_cholecystitsService.GetAll());
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody]CholecystitDTO cholecystitDto)
        {
            var lang = Request.Headers.AcceptLanguage.ToString();
            var res =  _cholecystitsService.Update(id, cholecystitDto);
            return res is not null ? Ok($"{_localization.Localize("SuccessfulUpdate", lang)} {res.Id}") : BadRequest(_localization.Localize("BadUpdate", lang));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var lang = Request.Headers.AcceptLanguage.ToString();
            var res = _cholecystitsService.Delete(id);
            return res is not null ? Ok($"{_localization.Localize("SuccessfulDelete", lang)} {res.Id}") : BadRequest(_localization.Localize("BadDelete", lang));
        }


    }
}