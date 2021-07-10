using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IRoomService : IBaseService<Room>
    {

    }
    public class RoomService : BaseService<Room>, IRoomService
    {
        private readonly IMapper _mapper;
        public RoomService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
