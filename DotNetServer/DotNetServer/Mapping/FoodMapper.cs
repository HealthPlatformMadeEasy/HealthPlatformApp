using DotNetServer.Entities.Foodb;
using DotNetServer.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Mapping;

[Mapper]
public static partial class FoodMapper
{
    public static partial FoodResponse FoodToFoodResponse(Food food);

    public static partial List<FoodResponse> FoodListToFoodResponseList(List<Food> food);
}