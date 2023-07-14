using DotNetServer.Entities;

namespace DotNetServer.Repositories;

public interface IFoodRepository
{
    Food GetFood(string food);
}