using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.FoodModule.Mapping;
using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;
using DotNetServer.Modules.FoodModule.Repositories;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Services;

namespace DotNetServer.Modules.FoodModule.Services;

public class FoodService : IFoodService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly IFoodRepository _foodRepository;
    private readonly IUserContentService _userContentService;

    public FoodService(IFoodRepository foodRepository, IUserContentService userContentService)
    {
        _foodRepository = foodRepository;
        _userContentService = userContentService;
        _cancellationTokenSource.CancelAfter(10000);
    }

    public async Task<Response<FoodResponse>> GetFood(FoodRequest request)
    {
        try
        {
            var dbResponse = await _foodRepository.GetFood(request.Food, _cancellationTokenSource.Token);

            if (dbResponse.Count == 0)
                return new Response<FoodResponse>
                {
                    Succeeded = false
                };

            var response = dbResponse.Select(FoodMapper.FoodToFoodResponse).Single();

            response.Contents.ForEach(row =>
            {
                row.OrigContent = row.OrigContent * request.Quantity / 100;
                row.StandardContent = row.StandardContent * request.Quantity / 100;
            });

            return new Response<FoodResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<FoodResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    // TODO refactor this logic
    public async Task<List<ContentResponse>> GetResultOfListFood(List<FoodRequest> requests)
    {
        var dbResponse = await _foodRepository.GetFoodsFromRequestList(requests
            .Select(item => item.Food)
            .ToList(), _cancellationTokenSource.Token);

        var response = dbResponse.Select(FoodMapper.FoodToFoodResponse)
            .ToList();


        foreach (var row in response.Select((item, index) => (item, index)))
            row.item.Contents.ForEach(cont =>
            {
                cont.OrigContent = cont.OrigContent * requests[row.index].Quantity / 100;
                cont.StandardContent = cont.StandardContent * requests[row.index].Quantity / 100;
            });

        var items = new List<ContentResponse>();
        response.ForEach(food => items.AddRange(food.Contents));

        var result = items.GroupBy(row => (row.OrigSourceName, row.OrigUnit, row.SourceType))
            .Select(row => new ContentResponse(row.Key.SourceType, row.Key.OrigUnit, row.Key.OrigSourceName)
            {
                OrigContent = row.Sum(cont => cont.OrigContent),
                StandardContent = row.Sum(cont => cont.StandardContent)
            }).OrderBy(row => row.OrigSourceName).ToList();

        return result;
    }

    public async Task<Response<List<ContentResponse>>> GetContentAndAddToUserContent(FullFoodRequest request)
    {
        try
        {
            var response = await GetResultOfListFood(request.FoodRequests);

            if (response.Count == 0)
                return new Response<List<ContentResponse>>
                {
                    Succeeded = false
                };

            var userContentDb = new List<UserContentRequest>();
            response.ForEach(row =>
            {
                var newRow = new UserContentRequest(
                    row.SourceType,
                    row.OrigUnit,
                    row.OrigSourceName,
                    row.OrigContent,
                    row.StandardContent,
                    request.UserId
                );
                userContentDb.Add(newRow);
            });

            await _userContentService.AddMultipleUserContentAsync(userContentDb);

            return new Response<List<ContentResponse>>(response);
        }
        catch (Exception e)
        {
            return new Response<List<ContentResponse>>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }
}