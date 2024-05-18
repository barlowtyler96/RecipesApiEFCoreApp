using System.ComponentModel.DataAnnotations;

namespace RecipeLibraryEFCore.Models;

public class Recipe
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public string? Instructions { get; set; }

    [Required]
    public string? CreatedBy { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }
    
    [MaxLength(200)]
    public string? ImageUrl { get; set; }

    public List<Ingredient> Ingredients { get; set; } = [];

    public List<User> FavoritedUsers { get; set; } = [];

}
