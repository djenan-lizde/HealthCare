using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.API.Services
{
    public interface IUserRoleService : IBaseService<UserRole>
    {

    }
    public class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
        private readonly IMapper _mapper;
        public UserRoleService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public override IEnumerable<UserRole> Get()
        {
            return _entity.Include(x => x.User).Where(x => x.Role == Role.Doctor).AsNoTracking().AsEnumerable();
        }
    }
}
