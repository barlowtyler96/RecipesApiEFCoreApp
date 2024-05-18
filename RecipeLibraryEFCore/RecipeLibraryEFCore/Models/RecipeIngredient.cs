using System.ComponentModel.DataAnnotations;

namespace RecipeLibraryEFCore.Models;

public class RecipeIngredient
{
    [Required]
    public int RecipeId { get; set; }

    [Required]
    public int IngredientId { get; set; }

    [Required]
    public float? Amount { get; set; }
   
}