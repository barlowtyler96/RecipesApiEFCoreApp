using RecipeLibraryEFCore.Models.Dtos;

namespace RecipeLibraryEFCore.DataAccess;

public interface IRecipeData
{
    Task<PaginationResponse<List<RecipeDto>>> GetAllRecipesAsync(int currentPageNumber, int pageSize);
    Task<PaginationResponse<List<RecipeDto>>> GetByDate(int currentPageNumber, int pageSize);
    Task<RecipeDto> GetByIdAsync(int id);
    Task<PaginationResponse<List<RecipeDto>>> GetByKeyword(string keyword, int currentPageNumber, int pageSize);
    Task<RecipeDto> AddRecipeAsync(RecipeDto newRecipeDto);
    Task DeleteRecipeAsync(int id);
}