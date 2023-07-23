using DotNetServer.FoodModule.Entities;
using DotNetServer.FoodModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.FoodModule.Mapping;

[Mapper]
public static partial class FoodMapper
{
    public static partial FoodResponse FoodToFoodResponse(Food food);

    public static partial List<FoodResponse> FoodListToFoodResponseList(List<Food> food);
}