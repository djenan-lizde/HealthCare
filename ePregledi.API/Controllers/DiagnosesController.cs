using ePregledi.API.Services;
using ePregledi.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ePregledi.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DiagnosesController : ControllerBase
    {
        private readonly IDiagnosisService _diagnosisService;

        public DiagnosesController(
            IDiagnosisService diagnosisService
            )
        {
            _diagnosisService = diagnosisService;
        }

        [HttpGet("{diagnosisId}")]
        public Diagnosis GetDiagnosis(int diagnosisId)
        {
            return _diagnosisService.GetById(diagnosisId);
        }

        [HttpPost("insert")]
        [Authorize(Roles = "Doctor")]
        public Diagnosis InsertDiagnosis(Diagnosis diagnosis)
        {
            return _diagnosisService.Insert(diagnosis);
        }

        [HttpPatch]
        [Authorize(Roles = "Doctor")]
        public Diagnosis UpdateDiagnosis([FromQuery] Diagnosis diagnosis)
        {
            return _diagnosisService.Update(diagnosis, diagnosis.Id);
        }

        [HttpGet("examination/{examinationId}")]
        public List<Diagnosis> GetExaminationDiagnosis(int examinationId)
        {
            return _diagnosisService.GetByCondition(x => x.ExaminationId == examinationId).ToList();
        }
    }
}
