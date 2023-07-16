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
        var dbResponse = _foodRepository.GetFood(request.Food).Select(row => FoodMapper.FoodToFoodResponse(row))
            .Single();

        dbResponse.Contents.ForEach(row =>
        {
            row.OrigContent = row.OrigContent * request.Quantity / 100;
            row.StandardContent = row.StandardContent * request.Quantity / 100;
        });

        return dbResponse;
    }
}