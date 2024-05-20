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
    public async Task<PaginationResponse<List<Recipe>>> Get(int currentPageNumber, int pageSize)
    {
        return await _data.GetAllRecipesAsync(currentPageNumber, pageSize);
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id}")]
    public async Task<Recipe> Get(int id)
    {
        Recipe recipe = await _data.GetByIdAsync(id);
        Console.WriteLine(recipe.RecipeIngredients[0].Ingredient.Name);
        Console.WriteLine(recipe.RecipeIngredients[0].Ingredient.Unit);
        Console.WriteLine(recipe.RecipeIngredients[0].Amount);
        return recipe;
    }

    // POST api/<RecipesController>
    [HttpPost]
    public async Task Post()
    {
        // Create the ingredients
        var pasta = new Ingredient
        {
            Name = "Pasta",
            Unit = "grams"
        };

        var tomatoes = new Ingredient
        {
            Name = "Tomatoes",
            Unit = "pieces"
        };

        var oliveOil = new Ingredient
        {
            Name = "Olive Oil",
            Unit = "ml"
        };

        // Create the recipe ingredients
        var recipeIngredients = new List<RecipeIngredient>
        {
            new RecipeIngredient
            {
                Ingredient = pasta,
                Amount = 200
            },
            new RecipeIngredient
            {
                Ingredient = tomatoes,
                Amount = 3
            },
            new RecipeIngredient
            {
                Ingredient = oliveOil,
                Amount = 50
            }
        };

        // Create the recipe
        var recipe = new Recipe
        {
            Name = "Potato Salad",
            Description = "A delicious potato salad with potatoes and olive oil.",
            Instructions = "1. Cook the potatoes. 2. Chop the tomatoes. 3. Mix everything with olive oil.",
            CreatedBy = "Chef Tyler",
            CreatedOn = DateTime.UtcNow,
            ImageUrl = "http://example.com/pasta-salad2.jpg",
            RecipeIngredients = recipeIngredients
        };
        await _data.AddRecipeAsync(recipe);
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
