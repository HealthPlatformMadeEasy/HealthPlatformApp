using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.NorwegianFoodModule.Entities;
using DotNetServer.Modules.NorwegianFoodModule.Model.Requests;
using DotNetServer.Modules.NorwegianFoodModule.Model.Responses;

namespace DotNetServer.Modules.NorwegianFoodModule.Services;

public interface INorwegianFoodService
{
    public NorwegianFood? GetNorwegianFoodById(Guid id);

    Task<Response<NorwegianFoodResponse>> GetNorwegianFoodByName(NorwegianFoodRequest request);

    Task<Response<TotalNutrientsResponse>> GetNorwegianFoodsByNameListOpenEndPoint(List<NorwegianFoodRequest> requests);

    Task<Response<TotalNutrientsResponse>> GetNorwegianFoodsAndAddNutrients(Guid userId,
        List<NorwegianFoodRequest> requests);
}