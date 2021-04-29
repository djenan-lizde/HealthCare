using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;

namespace ePregledi.API.Services
{
    public interface IRecipeService : IBaseService<Recipe>
    {

    }
    public class RecipeService : BaseService<Recipe>, IRecipeService
    {
        private readonly IMapper _mapper;
        public RecipeService(
            ApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
