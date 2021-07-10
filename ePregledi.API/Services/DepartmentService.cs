using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IDepartmentService : IBaseService<Department>
    {

    }
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IMapper _mapper;
        public DepartmentService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
