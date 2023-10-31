using Microsoft.AspNetCore.Mvc;
using Services;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ActuatorController : ControllerBase
    {
        private readonly IActuatorService _actuatorService;

        public ActuatorController(IActuatorService actuatorService)
        {
            _actuatorService = actuatorService;
        }

        [HttpGet("info")]
        public IActionResult GetInfo() => Ok(_actuatorService.MyInfo());

        [HttpGet("AssemblyInfo")]
        public IActionResult GetAssemblyInfo() => Ok(_actuatorService.GetAssemblyInfo());

        [HttpGet("ServiceInfo")]
        public IActionResult GetServiceInfo() => Ok(_actuatorService.GetServicesInfo());
    }
}