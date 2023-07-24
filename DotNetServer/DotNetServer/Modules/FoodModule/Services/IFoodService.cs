using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;

namespace DotNetServer.Modules.FoodModule.Services;

public interface IFoodService
{
    FoodResponse GetFood(FoodRequest request);

    List<ContentResponse> GetResultOfListFood(List<FoodRequest> requests);
}