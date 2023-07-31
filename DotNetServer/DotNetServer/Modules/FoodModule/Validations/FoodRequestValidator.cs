using DotNetServer.Modules.FoodModule.Model.Requests;
using FluentValidation;

namespace DotNetServer.Modules.FoodModule.Validations;

public class FoodRequestValidator : AbstractValidator<FoodRequest>
{
    public FoodRequestValidator()
    {
        RuleFor(prop => prop.Food).NotEmpty().NotNull();

        RuleFor(prop => prop.Quantity).GreaterThan(0);
    }
}