using DotNetServer.Entities;

namespace DotNetServer.Repositories;

public interface IFoodRepository
{
    List<Food> GetFood(string food);

    List<Food> GetFoodsFromRequestList(List<string> foodList);
}