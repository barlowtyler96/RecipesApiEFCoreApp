using System.ComponentModel.DataAnnotations;

namespace RecipeLibraryEFCore.Models;

public class UserFavorite
{
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}
