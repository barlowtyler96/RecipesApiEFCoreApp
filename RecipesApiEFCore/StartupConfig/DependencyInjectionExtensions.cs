using RecipeLibraryEFCore.DataAccess;

namespace RecipesApiEFCore.DependencyInjectionExtentions;

public static class DependencyInjectionExtensions
{
    public static void AddCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRecipeData, RecipeData>();
    }

    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

    }
}
