using DotNetServer.Modules.FoodModule.Entities;

namespace DotNetServer.Modules.FoodModule.Repositories;

public interface IFoodRepository
{
    List<Food> GetFood(string food);

    List<Food> GetFoodsFromRequestList(List<string> foodList);
}