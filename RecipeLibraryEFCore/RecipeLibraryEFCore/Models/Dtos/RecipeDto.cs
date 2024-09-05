using RecipeLibraryEFCore.Models.Entities;

namespace RecipeLibraryEFCore.Models.Dtos;

public class RecipeDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Instructions { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public required string ImageUrl { get; set; }
    public List<IngredientDto> Ingredients { get; set; } = [];
}
