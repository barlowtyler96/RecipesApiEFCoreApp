using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RecipeLibraryEFCore.DataAccess;
using RecipeLibraryEFCore.Models.Dtos;
using RecipeLibraryEFCore.Models.Entities;


namespace RecipesApiEFCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeData data) : ControllerBase
{
    private readonly IRecipeData _data = data;

    // GET: api/Recipes
    [HttpGet]
    public async Task<ActionResult<PaginationResponse<List<RecipeDto>>>> Get([FromQuery] int page, [FromQuery] int pageSize)
    {
        try
        {
            var output = await _data.GetAllRecipesAsync(page, pageSize);
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // GET api/Recipes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeDto>> GetById(int id)
    {
        try
        {
            var output = await _data.GetByIdAsync(id);
            if (output == null)
            {
                return NotFound(new { Message = $"Recipe with the id: {id} not found"});
            }
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    // POST api/Recipes
    [HttpPost]
    public async Task<ActionResult<RecipeDto>> Post([FromBody] RecipeDto newRecipeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdRecipe = await _data.AddRecipeAsync(newRecipeDto);
        var uri = "api/Recipes/" + createdRecipe.Id;
        return Created(uri, createdRecipe);
    }

    // POST api/Recipes
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _data.DeleteRecipeAsync(id);
    }
}
