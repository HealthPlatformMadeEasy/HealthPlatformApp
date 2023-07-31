using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Repositories;
using DotNetServer.Modules.UserModule.Services;
using DotNetServer.Modules.UserModule.Validations;
using FluentValidation;

namespace DotNetServer.Modules.UserModule;

public static class UserModuleExtension
{
    public static IServiceCollection AddUserModuleLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IValidator<MinimalUserRequest>, MinimalUserRequestValidator>();
        services.AddScoped<IValidator<UserRequest>, UserRequestValidator>();

        return services;
    }
}