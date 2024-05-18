using System.ComponentModel.DataAnnotations;

namespace RecipeLibraryEFCore.Models;

public class Ingredient
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(100)]
    public string? Unit { get; set; }
    public List<Recipe> Recipes { get; set; } = [];

}