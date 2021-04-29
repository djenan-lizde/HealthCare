using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IDiagnosisService : IBaseService<Diagnosis>
    {

    }
    public class DiagnosisService : BaseService<Diagnosis>, IDiagnosisService
    {
        private readonly IMapper _mapper;
        public DiagnosisService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
