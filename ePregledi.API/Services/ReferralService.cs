using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IReferralService : IBaseService<Referral>
    {

    }
    public class ReferralService : BaseService<Referral>, IReferralService
    {
        private readonly IMapper _mapper;
        public ReferralService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
