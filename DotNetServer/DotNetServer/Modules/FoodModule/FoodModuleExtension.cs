using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Repositories;
using DotNetServer.Modules.FoodModule.Services;
using DotNetServer.Modules.FoodModule.Validations;
using FluentValidation;

namespace DotNetServer.Modules.FoodModule;

public static class FoodModuleExtension
{
    public static IServiceCollection AddFoodModuleLayer(this IServiceCollection services)
    {
        services.AddScoped<IFoodRepository, FoodRepository>();
        services.AddScoped<IFoodService, FoodService>();

        services.AddScoped<IValidator<FoodRequest>, FoodRequestValidator>();
        services.AddScoped<IValidator<FullFoodRequest>, FullFoodRequestValidator>();

        return services;
    }
}