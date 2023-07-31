using DotNetServer.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core;

public static class CoreModuleExtension
{
    public static IServiceCollection AddCoreModuleLayer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<FoodbContext>(opt =>
            opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevFoodbMySQL")!));
        if (builder.Environment.IsProduction())
            services.AddDbContext<FoodbContext>(opt =>
                opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevFoodbMySQL")!));

        return services;
    }
}