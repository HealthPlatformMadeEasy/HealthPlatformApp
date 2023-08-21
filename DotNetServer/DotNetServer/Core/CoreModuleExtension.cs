using DotNetServer.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core;

public static class CoreModuleExtension
{
    public static IServiceCollection AddCoreModuleLayer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<NorwegianFoodDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("Production")));


        // services.AddDbContext<NorwegianFoodDbContext>(opt =>
        //     opt.UseNpgsql(builder.Configuration.GetConnectionString("Development")));

        return services;
    }
}