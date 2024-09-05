using System.ComponentModel.DataAnnotations;
using RecipeLibraryEFCore.Models.Dtos;

namespace RecipeLibraryEFCore.Models.Entities;

public class UserFavorite
{
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }

    public UserFavorite(UserFavoriteDto userFavoriteDto)
    {
        UserId = userFavoriteDto.UserId;
        RecipeId = userFavoriteDto.RecipeId;
    }
    public UserFavorite() { }
}
