using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeLibraryEFCore.Models.Dtos;
using RecipeLibraryEFCore.Models.Entities;
namespace RecipeLibraryEFCore.DataAccess;

public class UserData(RecipeContext sql, IMapper mapper) : IUserData
{
    private readonly RecipeContext _context = sql;
    private readonly IMapper _mapper = mapper;

    public async Task<UserDto> GetById(int id)
    {
        User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if(user == null)
        {
            return null;
        }
        UserDto userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
    public async Task AddUserFavorite(UserFavorite userFavorite)
    {
        _context.UserFavorites.Add(userFavorite);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteUserFavorite(UserFavorite userFavorite)
    {
        _context.UserFavorites.Remove(userFavorite);
        await _context.SaveChangesAsync();
    }
    public async Task<List<RecipeDto>> GetUserCreatedRecipes(string userSub)
    {
        throw new NotImplementedException();
    }
    public async Task<List<RecipeDto>> GetUserFavoriteRecipes(int userId)
    {
        var favoriteRecipes = await _context.UserFavorites
            .Where(uf => uf.UserId == userId)
            .Select(uf => uf.Recipe)
            .ToListAsync();

        var favoriteRecipeDtos = _mapper.Map<List<RecipeDto>>(favoriteRecipes);
        return favoriteRecipeDtos;
    }
    public async Task<List<int>> GetUserFavorites(int userId)
    {
        var favoriteRecipes = await _context.UserFavorites
            .Where(uf => uf.UserId == userId)
            .Select(uf => uf.RecipeId)
            .ToListAsync();
        return favoriteRecipes;
    }
    public async Task AddNewUser(UserDto newUserDto)
    {
        User newUser = _mapper.Map<User>(newUserDto);
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
    }
}
