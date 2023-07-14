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
        var dbResponse = _foodRepository.GetFood(request.Food);

        var contentList = dbResponse.Contents.Select(row =>
        {
            var foodCalculation = row.OrigContent * request.Quantity / 100;
            return new ContentResponse(
                row.SourceId,
                row.SourceType,
                foodCalculation,
                row.OrigUnit,
                row.StandardContent);
        }).ToList();


        var foodResponse = new FoodResponse(
            dbResponse.Name,
            dbResponse.Description,
            dbResponse.FoodGroup,
            contentList);

        return foodResponse;
    }
}