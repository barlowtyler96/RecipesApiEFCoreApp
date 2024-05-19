using RecipeLibraryEFCore.Models;

namespace RecipeLibraryEFCore.DataAccess
{
    public interface IRecipeData
    {
        Task<PaginationResponse<List<Recipe>>> GetAllRecipes(int currentPageNumber, int pageSize);
        Task<PaginationResponse<List<Recipe>>> GetByDate(int currentPageNumber, int pageSize);
        Task<Recipe> GetById(int id);
        Task<PaginationResponse<List<Recipe>>> GetByKeyword(string keyword, int currentPageNumber, int pageSize);
        Task AddRecipeAsync();
    }
}