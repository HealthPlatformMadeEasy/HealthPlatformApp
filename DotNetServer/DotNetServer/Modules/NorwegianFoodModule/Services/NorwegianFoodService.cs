using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.NorwegianFoodModule.Entities;
using DotNetServer.Modules.NorwegianFoodModule.Mapping;
using DotNetServer.Modules.NorwegianFoodModule.Model.Requests;
using DotNetServer.Modules.NorwegianFoodModule.Model.Responses;
using DotNetServer.Modules.NorwegianFoodModule.Repositories;
using DotNetServer.Modules.NutrientModule.Model.Requests;
using DotNetServer.Modules.NutrientModule.Services;

namespace DotNetServer.Modules.NorwegianFoodModule.Services;

public class NorwegianFoodService : INorwegianFoodService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly INorwegianFoodRepository _norwegianFoodRepository;
    private readonly INutrientService _nutrientService;

    public NorwegianFoodService(INorwegianFoodRepository norwegianFoodRepository, INutrientService nutrientService)
    {
        _norwegianFoodRepository = norwegianFoodRepository;
        _nutrientService = nutrientService;
        _cancellationTokenSource.CancelAfter(10000);
    }

    public NorwegianFood? GetNorwegianFoodById(Guid id)
    {
        return _norwegianFoodRepository.GetNorwegianFoodById(id);
    }

    public async Task<Response<NorwegianFoodResponse>> GetNorwegianFoodByName(NorwegianFoodRequest request)
    {
        try
        {
            var dbResponse =
                await _norwegianFoodRepository.GetNorwegianFoodByName(request.FoodName, _cancellationTokenSource.Token);

            if (dbResponse is null) return new Response<NorwegianFoodResponse> { Succeeded = false };

            dbResponse.SetPerQuantityValues(dbResponse, request);

            var response = NorwegianFoodMapper.NorwegianFoodToNorwegianFoodResponse(dbResponse);

            return new Response<NorwegianFoodResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<NorwegianFoodResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task<Response<TotalNutrientsResponse>> GetNorwegianFoodsByNameListOpenEndPoint(
        List<NorwegianFoodRequest> requests)
    {
        try
        {
            var response = await GetNorwegianFoodsByNameList(requests);

            return response is null
                ? new Response<TotalNutrientsResponse> { Succeeded = false }
                : new Response<TotalNutrientsResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<TotalNutrientsResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task<Response<TotalNutrientsResponse>> GetNorwegianFoodsAndAddNutrients(Guid userId,
        List<NorwegianFoodRequest> requests)
    {
        try
        {
            var response = await GetNorwegianFoodsByNameList(requests);

            if (response is null) return new Response<TotalNutrientsResponse> { Succeeded = false };

            var safeResponse = new NutrientRequest();
            safeResponse.SetNutrientRequest(response, userId);

            await _nutrientService.AddNutrientAsync(safeResponse);

            return new Response<TotalNutrientsResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<TotalNutrientsResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    // TODO make extra function to open endpoint for test
    private async Task<TotalNutrientsResponse?> GetNorwegianFoodsByNameList(
        List<NorwegianFoodRequest> requests)
    {
        var dbResponses = await
            _norwegianFoodRepository.GetNorwegianFoodsByNameList(requests.Select(row => row.FoodName).ToList(),
                _cancellationTokenSource.Token);

        if (dbResponses is null || !dbResponses.Any()) return null;

        var sortedDbResponse = dbResponses!.OrderBy(row => row.FoodName).ToList();
        var sortedRequests = requests.OrderBy(row => row.FoodName).ToList();

        for (var i = 0; i < sortedDbResponse.Count; i++)
            sortedDbResponse[i].SetPerQuantityValues(sortedDbResponse[i], sortedRequests[i]);

        var response = new TotalNutrientsResponse();

        response.GetTotalNutrientsResponse(sortedDbResponse);

        return response;
    }
}