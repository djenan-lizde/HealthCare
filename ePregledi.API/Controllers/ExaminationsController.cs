using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ePregledi.API.Services;
using ePregledi.Models.Models;
using ePregledi.Models.Requests;
using ePregledi.Models.Responses;

namespace ePregledi.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationService _examinationService;
        private readonly IDiagnosisService _diagnosisService;
        private readonly IRecipeService _recipeService;
        private readonly IReferralService _referralService;

        public ExaminationsController(
            IExaminationService examinationService,
            IDiagnosisService diagnosisService,
            IRecipeService recipeService,
            IReferralService referralService
            )
        {
            _examinationService = examinationService;
            _diagnosisService = diagnosisService;
            _recipeService = recipeService;
            _referralService = referralService;
        }

        [HttpGet("{examinationId}")]
        public Examination GetExamination(int examinationId)
        {
            return _examinationService.GetById(examinationId);
        }

        [HttpGet("filter")]
        public IEnumerable<ExaminationViewModel> GetExaminations([FromQuery] SearchExamination request)
        {
            return _examinationService.GetExaminations(request);
        }

        [HttpPost("insert")]
        [Authorize(Roles = "Patient")]
        public Examination InsertExamination(Examination examination)
        {
            return _examinationService.Insert(examination);
        }

        [HttpGet("patient/{userId}")]
        public List<Examination> GetPatientExaminations(int userId)
        {
            return _examinationService.GetByCondition(x => x.PatientId == userId).ToList();
        }

        [HttpGet("doctor/{userId}")]
        public List<Examination> GetDoctorExaminations(int userId)
        {
            return _examinationService.GetByCondition(x => x.DoctorId == userId).ToList();
        }

        [HttpPut("rate")]
        public Examination UpdateExamination(Examination examination)
        {
            return _examinationService.Update(examination, examination.Id);
        }

        [HttpGet("details/{examinationId}")]
        public ExaminationDetails GetExaminationDetails(int examinationId)
        {
            return _examinationService.GetExaminationDetails(examinationId);
        }

        [HttpPost("details")]
        [Authorize(Roles = "Doctor")]
        public ExaminationDetails InsertExaminationDetails(ExaminationDetails exDet)
        {
            var diagnosis = _diagnosisService.Insert(exDet.Diagnosis);

            exDet.Recipe.DiagnosisId = diagnosis.Id;

            _recipeService.Insert(exDet.Recipe);
            _referralService.Insert(exDet.Referral);

            return exDet;
        }

        [HttpPost("availability")]
        public bool CheckAvailability(ExaminationAvailability examination)
        {
            var examinations = _examinationService.GetByCondition(x => x.ExaminationDate.Date == examination.ExaminationDate.Date
                    && x.DoctorId == examination.DoctorId);

            var numberOfExaminations = examinations.Where(x => x.ExaminationTime.Hours == examination.ExaminationTime.Hours).Count();

            if (numberOfExaminations == 2)
                return false;

            return true;
        }
    }
}
