using ePregledi.API.Services;
using ePregledi.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePregledi.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReferralsController : ControllerBase
    {
        private readonly IReferralService _referralService;

        public ReferralsController(
            IReferralService referralService
            )
        {
            _referralService = referralService;
        }

        [HttpGet("{referralId}")]
        public Referral GetReferral(int referralId)
        {
            return _referralService.GetById(referralId);
        }

        [HttpPost("insert")]
        public Referral InsertReferral(Referral referral)
        {
            return _referralService.Insert(referral);
        }

        [HttpPatch]
        public Referral UpdateReferral([FromQuery] Referral referral)
        {
            return _referralService.Update(referral,referral.Id);
        }
    }
}
