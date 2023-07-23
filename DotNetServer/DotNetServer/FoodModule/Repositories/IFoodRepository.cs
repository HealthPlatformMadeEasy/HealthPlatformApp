using DotNetServer.FoodModule.Entities;

namespace DotNetServer.FoodModule.Repositories;

public interface IFoodRepository
{
    List<Food> GetFood(string food);

    List<Food> GetFoodsFromRequestList(List<string> foodList);
}