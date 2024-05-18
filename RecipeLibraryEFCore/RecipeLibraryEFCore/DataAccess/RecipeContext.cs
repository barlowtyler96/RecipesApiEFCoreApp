using Microsoft.EntityFrameworkCore;
using RecipeLibraryEFCore.Models;

namespace RecipeLibraryEFCore.DataAccess;

public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserFavorite> UserFavorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasMany(e => e.Ingredients)
            .WithMany(e => e.Recipes)
            .UsingEntity<RecipeIngredient>();

        modelBuilder.Entity<Recipe>()
            .HasMany(e => e.FavoritedUsers)
            .WithMany(e => e.FavoriteRecipes)
            .UsingEntity<UserFavorite>();
    }
}
