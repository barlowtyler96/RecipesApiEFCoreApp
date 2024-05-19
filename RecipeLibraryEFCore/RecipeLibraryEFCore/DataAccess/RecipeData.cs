using Microsoft.EntityFrameworkCore;
using RecipeLibraryEFCore.Models;
namespace RecipeLibraryEFCore.DataAccess;

public class RecipeData(RecipeContext context) : IRecipeData
{
    private readonly RecipeContext _context = context;

    //GET
    public async Task<Recipe> GetByIdAsync(int id)
    {
        var recipeResponse = await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == id);
        return recipeResponse;
    }

    //GET
    public async Task<PaginationResponse<List<Recipe>>> GetAllRecipesAsync(int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;
        int take = pageSize;

        int totalCount = await _context.Recipes.CountAsync();
        List<Recipe> recipesResponse = await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .Take(take)
            .Skip(skip)
            .ToListAsync();

        PaginationResponse<List<Recipe>> paginationResponse = new(totalCount, pageSize, currentPageNumber, recipesResponse);
        return paginationResponse;
    }

    //GET
    public async Task<PaginationResponse<List<Recipe>>> GetByDate(int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;
        int take = pageSize;

        throw new NotImplementedException();
    }

    public async Task<PaginationResponse<List<Recipe>>> GetByKeyword(string keyword, int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;
        int take = pageSize;

        throw new NotImplementedException();
    }

    public async Task AddRecipeAsync()
    {
        var recipe = new Recipe
        {
            Name = "Chocolate Cake",
            Description = "A delicious chocolate cake recipe",
            Instructions = "Mix ingredients and bake",
            CreatedBy = "Tyler",
            CreatedOn = DateTime.UtcNow,
            ImageUrl = "myimg.com",
            RecipeIngredients = new List<RecipeIngredient>()
        };

        var ingredient1 = new Ingredient
        {
            Name = "Flour",
            Unit = "cups"
        };

        var ingredient2 = new Ingredient
        {
            Name = "Sugar",
            Unit = "cups"
        };

        var ingredient3 = new Ingredient
        {
            Name = "Cocoa Powder",
            Unit = "cups"
        };

        _context.Recipes.Add(recipe);
        _context.Ingredients.AddRange(ingredient1, ingredient2, ingredient3);

        await _context.SaveChangesAsync();

        recipe.RecipeIngredients.Add(new RecipeIngredient
        {
            RecipeId = recipe.Id,
            IngredientId = ingredient1.Id,
            Amount = 2.0
        });

        recipe.RecipeIngredients.Add(new RecipeIngredient
        {
            RecipeId = recipe.Id,
            IngredientId = ingredient2.Id,
            Amount = 1.5
        });

        recipe.RecipeIngredients.Add(new RecipeIngredient
        {
            RecipeId = recipe.Id,
            IngredientId = ingredient3.Id,
            Amount = 1.0
        });

        await _context.SaveChangesAsync();
    }
}
