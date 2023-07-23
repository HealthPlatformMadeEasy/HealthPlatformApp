using DotNetServer.Modules.FoodModule.Entities;
using DotNetServer.Modules.FoodModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Modules.FoodModule.Mapping;

[Mapper]
public static partial class FoodMapper
{
    public static partial FoodResponse FoodToFoodResponse(Food food);

    public static partial List<FoodResponse> FoodListToFoodResponseList(List<Food> food);
}