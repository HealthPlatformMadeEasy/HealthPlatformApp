using DotNetServer.Modules.NorwegianFoodModule.Repositories;
using DotNetServer.Modules.NorwegianFoodModule.Services;

namespace DotNetServer.Modules.NorwegianFoodModule;

public static class NorwegianFoodModuleExtension
{
    public static IServiceCollection AddNorwegianFoodModuleLayer(this IServiceCollection services)
    {
        services.AddScoped<INorwegianFoodRepository, NorwegianFoodRepository>();
        services.AddScoped<INorwegianFoodService, NorwegianFoodService>();

        return services;
    }
}