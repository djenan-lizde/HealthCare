using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IMedicineService : IBaseService<Medicine>
    {

    }
    public class MedicineService : BaseService<Medicine>, IMedicineService
    {
        public MedicineService(
                 ApplicationDbContext context,
                 IMapper mapper
                 ) : base(context, mapper)
        {
        }

    }
}
