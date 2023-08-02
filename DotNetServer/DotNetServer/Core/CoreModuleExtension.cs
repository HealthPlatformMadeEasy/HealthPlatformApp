using DotNetServer.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetServer.Core;

public static class CoreModuleExtension
{
    public static IServiceCollection AddCoreModuleLayer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<FoodbContext>(opt =>
            opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevFoodbMySQL")!,
                efConfig => efConfig.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    "foodb")));
        if (builder.Environment.IsProduction())
            services.AddDbContext<FoodbContext>(opt =>
                opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevFoodbMySQL")!,
                    efConfig => efConfig.MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        "foodb")));

        services.AddDbContext<NorwegianFoodDbContext>(opt =>
            opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevNorwegianFoodDbMySQL")!,
                efConfig => efConfig.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    "fooddb")));

        return services;
    }
}