using DotNetServer.Modules.UserModule.Model.Requests;
using FluentValidation;

namespace DotNetServer.Modules.UserModule.Validations;

public class MinimalUserRequestValidator : AbstractValidator<MinimalUserRequest>
{
    public MinimalUserRequestValidator()
    {
        RuleFor(u => u.Email).EmailAddress();

        RuleFor(u => u.Password).MinimumLength(8);

        RuleFor(u => u.Name).NotEmpty().NotNull();
    }
}