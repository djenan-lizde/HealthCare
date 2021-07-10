using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IAmbulanceService : IBaseService<Ambulance>
    {

    }
    public class AmbulanceService : BaseService<Ambulance>, IAmbulanceService
    {
        private readonly IMapper _mapper;
        public AmbulanceService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
