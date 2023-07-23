using DotNetServer.UserModule.Model.Requests;
using FluentValidation;

namespace DotNetServer.UserModule.Validations;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(u => u.Name).NotEmpty().NotNull();

        RuleFor(u => u.Email).EmailAddress();

        RuleFor(u => u.Password).MinimumLength(8);
    }
}