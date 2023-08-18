using DotNetServer.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core;

public static class CoreModuleExtension
{
    public static IServiceCollection AddCoreModuleLayer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // if (builder.Environment.IsProduction())
        services.AddDbContext<NorwegianFoodDbContext>(opt =>
            opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:ProNorwegianFoodDbMySQL")!));

        // if (builder.Environment.IsDevelopment())
        //     services.AddDbContext<NorwegianFoodDbContext>(opt =>
        //     opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevNorwegianFoodDbMySQL")!));

        return services;
    }
}