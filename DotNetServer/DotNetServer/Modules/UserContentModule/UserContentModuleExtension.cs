using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Repositories;
using DotNetServer.Modules.UserContentModule.Services;
using DotNetServer.Modules.UserContentModule.Validations;
using FluentValidation;

namespace DotNetServer.Modules.UserContentModule;

public static class UserContentModuleExtension
{
    public static IServiceCollection AddUserContentModuleLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserContentRepository, UserContentRepository>();
        services.AddScoped<IUserContentService, UserContentService>();
        services.AddScoped<IValidator<UserContentRequest>, UserContentRequestValidator>();

        return services;
    }
}