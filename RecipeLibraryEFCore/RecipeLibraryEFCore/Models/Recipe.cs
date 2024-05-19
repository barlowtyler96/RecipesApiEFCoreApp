using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<RecipeIngredient> RecipeIngredients { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<UserFavorite> UserFavorites { get; set; }

}
