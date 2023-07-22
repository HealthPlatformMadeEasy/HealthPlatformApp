using DotNetServer.Mapping;
using DotNetServer.Model.Requests;
using DotNetServer.Model.Responses;
using DotNetServer.Repositories;

namespace DotNetServer.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public FoodResponse GetFood(FoodRequest request)
    {
        var dbResponse = _foodRepository.GetFood(request.Food).Select(FoodMapper.FoodToFoodResponse)
            .Single();

        dbResponse.Contents.ForEach(row =>
        {
            row.OrigContent = row.OrigContent * request.Quantity / 100;
            row.StandardContent = row.StandardContent * request.Quantity / 100;
        });

        return dbResponse;
    }

    // TODO refactor this logic
    public List<ContentResponse> GetResultOfListFood(List<FoodRequest> requests)
    {
        var dbResponse = _foodRepository.GetFoodsFromRequestList(requests
                .Select(item => item.Food)
                .ToList())
            .Select(FoodMapper.FoodToFoodResponse)
            .ToList();


        foreach (var row in dbResponse.Select((item, index) => (item, index)))
            row.item.Contents.ForEach(cont =>
            {
                cont.OrigContent = cont.OrigContent * requests[row.index].Quantity / 100;
                cont.StandardContent = cont.StandardContent * requests[row.index].Quantity / 100;
            });

        var items = new List<ContentResponse>();
        dbResponse.ForEach(food => items.AddRange(food.Contents));

        var result = items.GroupBy(row => (row.OrigSourceName, row.OrigUnit, row.SourceType))
            .Select(row => new ContentResponse(row.Key.SourceType, row.Key.OrigUnit, row.Key.OrigSourceName)
            {
                OrigContent = row.Sum(cont => cont.OrigContent),
                StandardContent = row.Sum(cont => cont.StandardContent)
            }).OrderBy(row => row.OrigSourceName).ToList();

        return result;
    }
}