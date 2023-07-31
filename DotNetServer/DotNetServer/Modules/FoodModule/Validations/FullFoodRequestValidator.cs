using DotNetServer.Modules.FoodModule.Model.Requests;
using FluentValidation;

namespace DotNetServer.Modules.FoodModule.Validations;

public class FullFoodRequestValidator : AbstractValidator<FullFoodRequest>
{
    public FullFoodRequestValidator()
    {
        RuleFor(prop => prop.UserId).NotEmpty().NotNull();

        RuleForEach(prop => prop.FoodRequests).SetValidator(new FoodRequestValidator());
    }
}