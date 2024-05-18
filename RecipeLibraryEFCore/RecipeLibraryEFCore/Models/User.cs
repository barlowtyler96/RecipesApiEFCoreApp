using System.ComponentModel.DataAnnotations;

namespace RecipeLibraryEFCore.Models;

public class User
{
    [Required]
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string? UserSub { get; set; } 

    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    [Required]
    public string? LastName { get; set; }
    public List<Recipe> FavoriteRecipes { get; set; } = [];
}
