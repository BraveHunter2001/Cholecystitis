using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public IActionResult Create(PatientDto patientDto)
        {
            var patient = _patientService.Create(patientDto.Name, patientDto.Age, patientDto.Gender,patientDto.RiskFactors);
            return Ok(patient);
        }

        [HttpGet]
        public IActionResult Get([FromQuery]Guid id) {
            return Ok(_patientService.GetPatient(id));
        }
    }
}
