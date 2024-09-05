using Microsoft.EntityFrameworkCore;
using RecipeLibraryEFCore.DataAccess;

namespace RecipesApiEFCore.DependencyInjectionExtentions;

public static class DependencyInjectionExtensions
{
    public static void AddEFCoreServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<RecipeContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });
    }
    public static void AddCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRecipeData, RecipeData>();
        builder.Services.AddScoped<IUserData, UserData>();
    }

    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
    }
}
