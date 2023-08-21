using DotNetServer.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core;

public static class CoreModuleExtension
{
    public static IServiceCollection AddCoreModuleLayer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<NorwegianFoodDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration["Production"] ??
                          throw new InvalidOperationException("Connection string not found.")));


        // services.AddDbContext<NorwegianFoodDbContext>(opt =>
        //     opt.UseNpgsql(builder.Configuration["Development"] ?? throw new InvalidOperationException("Connection string not found.")));

        return services;
    }
}