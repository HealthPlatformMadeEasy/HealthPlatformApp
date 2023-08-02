namespace DotNetServer.Modules.NorwegianFoodModule.Model.Requests;

public record NorwegianFoodRequest(
    string FoodName,
    double Quantity
);