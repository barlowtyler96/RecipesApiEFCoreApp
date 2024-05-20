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

    public async Task AddRecipeAsync(Recipe newRecipe)
    {
        foreach (var recipeIngredient in newRecipe.RecipeIngredients)
        {
            // Check if the ingredient already exists
            var existingIngredient = await _context.Ingredients
                .FirstOrDefaultAsync(i => i.Name == recipeIngredient.Ingredient.Name);

            if (existingIngredient != null)
            {
                // Use the existing ingredient
                recipeIngredient.IngredientId = existingIngredient.Id;
                recipeIngredient.Ingredient = existingIngredient;
            }
            else
            {
                // Add the new ingredient to the context
                _context.Ingredients.Add(recipeIngredient.Ingredient);
            }
        }

        _context.Recipes.Add(newRecipe);
        await _context.SaveChangesAsync();
    }
}
