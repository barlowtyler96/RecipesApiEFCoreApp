using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeLibraryEFCore.Models.Dtos;
using RecipeLibraryEFCore.Models.Entities;
namespace RecipeLibraryEFCore.DataAccess;

public class RecipeData(RecipeContext context, IMapper mapper) : IRecipeData
{
    private readonly RecipeContext _context = context;
    private readonly IMapper _mapper = mapper;

    //GET
    public async Task<RecipeDto> GetByIdAsync(int id)
    {
        var recipeResponse = await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (recipeResponse == null)
        {
            return null!;
        }

        RecipeDto createdRecipe = _mapper.Map<RecipeDto>(recipeResponse);
        return createdRecipe;
    }

    //GET
    public async Task<PaginationResponse<List<RecipeDto>>> GetAllRecipesAsync(int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;
        int take = pageSize;

        int totalCount = await _context.Recipes.CountAsync();
        List<Recipe> recipesResponse = await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .OrderBy(r => r.Id)
            .Take(take)
            .Skip(skip)
            .ToListAsync();

        List<RecipeDto> recipeDtos = _mapper.Map<List<RecipeDto>>(recipesResponse);

        PaginationResponse<List<RecipeDto>> paginationResponse = new(totalCount, pageSize, currentPageNumber, recipeDtos);
        return paginationResponse;
    }

    //GET
    public async Task<PaginationResponse<List<RecipeDto>>> GetByDate(int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;
        int take = pageSize;

        int totalCount = await _context.Recipes.CountAsync();
        List<Recipe> recipesResponse = await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .OrderBy(r => r.CreatedOn)
            .Take(take)
            .Skip(skip)
            .ToListAsync();
        List<RecipeDto> recipeDtos = _mapper.Map<List<RecipeDto>>(recipesResponse);
        PaginationResponse<List<RecipeDto>> paginationResponse = new(totalCount, pageSize, currentPageNumber, recipeDtos);
        return paginationResponse;
    }

    //GET
    public async Task<PaginationResponse<List<RecipeDto>>> GetByKeyword(string keyword, int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;
        int take = pageSize;

        throw new NotImplementedException();
    }

    //POST
    public async Task<RecipeDto> AddRecipeAsync(RecipeDto newRecipeDto)
    {
        Recipe newRecipe = _mapper.Map<Recipe>(newRecipeDto);

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
        RecipeDto createdRecipe = _mapper.Map<RecipeDto>(newRecipe);
        return createdRecipe;
    }

    //DELETE
    public async Task DeleteRecipeAsync(int id)
    {
        Recipe recipe = _context.Recipes.Find(id)!;
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}
