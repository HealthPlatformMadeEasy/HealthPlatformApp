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

    public List<FoodResponse> GetResultOfListFood(List<FoodRequest> requests)
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

        /* TODO
         add all list of content then
         var result = items.GroupBy(x => x.name).Select(g => new { name = g.Key, money = g.Sum(x => x.money) }).ToList();
        that will return a list with no repeated element and add the value column */

        return dbResponse;
    }
}