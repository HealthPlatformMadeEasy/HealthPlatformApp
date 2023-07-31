using DotNetServer.Modules.FoodModule.Entities;

namespace DotNetServer.Modules.FoodModule.Repositories;

public interface IFoodRepository
{
    Task<List<Food>> GetFood(string food, CancellationToken cancellationToken);

    Task<List<Food>> GetFoodsFromRequestList(List<string> foodList, CancellationToken cancellationToken);
}