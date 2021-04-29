using ePregledi.API.Services;
using ePregledi.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePregledi.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(
            IRecipeService recipeService
            )
        {
            _recipeService = recipeService;
        }

        [HttpGet("{recipeId}")]
        public Recipe GetDiagnosis(int recipeId)
        {
            return _recipeService.GetById(recipeId);
        }

        [HttpPost("insert")]
        public Recipe InsertRecipe(Recipe recipe)
        {
            return _recipeService.Insert(recipe);
        }

        [HttpPatch]
        public Recipe UpdateRecipe([FromQuery] Recipe recipe)
        {
            return _recipeService.Update(recipe, recipe.Id);
        }
    }
}
