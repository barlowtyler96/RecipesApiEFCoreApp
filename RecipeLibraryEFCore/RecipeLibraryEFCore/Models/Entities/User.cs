using System.ComponentModel.DataAnnotations;
using RecipeLibraryEFCore.Models.Dtos;

namespace RecipeLibraryEFCore.Models.Entities;

public class User
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string FirstName { get; set; }

    [MaxLength(100)]
    [Required]
    public required string LastName { get; set; }
    public List<UserFavorite> UserFavorites { get; set; } = [];

    public User(UserDto userDto)
    {
        Id = userDto.Id;
        FirstName = userDto.FirstName;
        LastName = userDto.LastName;
    }
    public User() { }
}
