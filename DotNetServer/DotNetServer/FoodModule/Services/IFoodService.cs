using DotNetServer.FoodModule.Model.Requests;
using DotNetServer.FoodModule.Model.Responses;

namespace DotNetServer.FoodModule.Services;

public interface IFoodService
{
    FoodResponse GetFood(FoodRequest request);

    List<ContentResponse> GetResultOfListFood(List<FoodRequest> requests);
}