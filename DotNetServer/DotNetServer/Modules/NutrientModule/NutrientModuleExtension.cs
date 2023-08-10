using DotNetServer.Modules.NutrientModule.Repositories;
using DotNetServer.Modules.NutrientModule.Services;

namespace DotNetServer.Modules.NutrientModule;

public static class NutrientModuleExtension
{
    public static IServiceCollection AddNutrientModuleLayer(this IServiceCollection services)
    {
        services.AddScoped<INutrientRepository, NutrientRepository>();
        services.AddScoped<INutrientService, NutrientService>();

        return services;
    }
}