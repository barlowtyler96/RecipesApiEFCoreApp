using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RecipeLibraryEFCore.Models.Dtos;

namespace RecipeLibraryEFCore.Models.Entities;

public class Recipe
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required string Instructions { get; set; }

    [Required]
    public required string CreatedBy { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    [MaxLength(200)]
    public required string ImageUrl { get; set; }

    //Navigation property
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<RecipeIngredient> RecipeIngredients { get; set; } = [];

    //Navigation property
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<UserFavorite> UserFavorites { get; set; } = [];
}
