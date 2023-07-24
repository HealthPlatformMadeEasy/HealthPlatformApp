using DotNetServer.Modules.UserContentModule.Model.Requests;
using FluentValidation;

namespace DotNetServer.Modules.UserContentModule.Validations;

public class UserContentRequestValidator : AbstractValidator<UserContentRequest>
{
    public UserContentRequestValidator()
    {
        RuleFor(u => u.UserId).NotNull().NotEmpty();
    }
}