using Microsoft.EntityFrameworkCore;
using RecipeLibraryEFCore.Models;
namespace RecipeLibraryEFCore.DataAccess;

public class RecipeData(RecipeContext context)
{
    private readonly RecipeContext _context = context;  

    //GET
    public async Task<PaginationResponse<List<Recipe>>> GetAllRecipes(int currentPageNumber, int pageSize)
    {
        int skip = (currentPageNumber - 1) * pageSize;  
        int take = pageSize;

        
        throw new NotImplementedException();
    }

    //GET
    public async Task<Recipe> GetById(int id)
    {
        var recipe = await _context.Recipes
        .FirstOrDefaultAsync(r => r.Id == id);
        return recipe;
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
}
