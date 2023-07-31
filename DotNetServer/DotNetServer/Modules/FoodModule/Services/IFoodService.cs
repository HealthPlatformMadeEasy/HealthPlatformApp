using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;

namespace DotNetServer.Modules.FoodModule.Services;

public interface IFoodService
{
    Task<Response<FoodResponse>> GetFood(FoodRequest request);

    Task<List<ContentResponse>> GetResultOfListFood(List<FoodRequest> requests);

    Task<Response<List<ContentResponse>>> GetContentAndAddToUserContent(FullFoodRequest request);
}