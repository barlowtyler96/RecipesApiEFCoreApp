using RecipeLibraryEFCore.Models.Dtos;
using RecipeLibraryEFCore.Models.Entities;

namespace RecipeLibraryEFCore.DataAccess;

public interface IUserData
{
    Task<UserDto> GetById(int id);
    Task AddNewUser(UserDto newUserDto);
    Task AddUserFavorite(UserFavorite userFavorite);
    Task DeleteUserFavorite(UserFavorite userFavorite);
    Task<List<RecipeDto>> GetUserFavoriteRecipes(int userId);
    Task<List<int>> GetUserFavorites(int userId);                                                                     
}