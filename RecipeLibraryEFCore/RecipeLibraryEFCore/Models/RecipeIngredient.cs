using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipeLibraryEFCore.Models;

public class RecipeIngredient
{
    [Required]
    public int RecipeId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Recipe Recipe { get; set; }

    [Required]
    public int IngredientId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Ingredient Ingredient { get; set; }

    [Required]
    public double Amount { get; set; }
   
}