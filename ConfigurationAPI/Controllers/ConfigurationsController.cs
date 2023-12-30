using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ConfigurationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ConfigurationsController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllConfigurationProviders() {

            var configs = ((IConfigurationRoot)_configuration).Providers.Select(p=>p.ToString());
            var sb = new StringBuilder();
            sb.AppendJoin(",\n", configs);
            return Ok(sb.ToString());
        }

        [HttpGet("{envType}")]
        public IActionResult GetConfigurationList(string envType)
        {

            string envConf = envType switch
            {
                "dev" => "dev-conf",
                "prod" => "prod-conf",
                "stag" => "stag-conf",
                _ => "dev-conf"
            } ;

            var configs =_configuration.GetSection(envConf).GetChildren().Select(p=>p.Key +"-"+ p.Value);

            var sb = new StringBuilder();
            sb.AppendJoin(",\n", configs);
            return Ok(sb.ToString());
        }

        [HttpGet]
        public IActionResult GetDbConnect()
        {

            var configs = _configuration.GetSection("prod-conf").GetSection("db").Value;
            Console.WriteLine($"Was requested config connetction string from {HttpContext.Request.Host}");
            return Ok(configs);
        }
    }
}
