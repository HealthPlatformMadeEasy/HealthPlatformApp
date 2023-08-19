using DotNetServer.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core;

public static class CoreModuleExtension
{
    public static IServiceCollection AddCoreModuleLayer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // services.AddDbContext<NorwegianFoodDbContext>(opt =>
        //     opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:ProNorwegianFoodDbMySQL")!));


        services.AddDbContext<NorwegianFoodDbContext>(opt =>
            opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevNorwegianFoodDbMySQL")!));

        return services;
    }
}