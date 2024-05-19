using Microsoft.AspNetCore.Mvc;
using RecipeLibraryEFCore.DataAccess;
using RecipeLibraryEFCore.Models;


namespace RecipesApiEFCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeData data) : ControllerBase
{
    private readonly IRecipeData _data = data;

    // GET: api/<RecipesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id}")]
    public async Task<Recipe> Get(int id)
    {
        Recipe recipe = await _data.GetById(id);
        Console.WriteLine(recipe.RecipeIngredients[0].Ingredient.Name);
        Console.WriteLine(recipe.RecipeIngredients[0].Ingredient.Unit);
        Console.WriteLine(recipe.RecipeIngredients[0].Amount);
        return recipe;
    }

    // POST api/<RecipesController>
    [HttpPost]
    public async Task Post()
    {
        await _data.AddRecipeAsync();
    }

    // PUT api/<RecipesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<RecipesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
