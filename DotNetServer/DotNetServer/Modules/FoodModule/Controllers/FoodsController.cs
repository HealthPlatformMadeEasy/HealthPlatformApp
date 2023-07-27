using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;
using DotNetServer.Modules.FoodModule.Services;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.FoodModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly IUserContentService _userContentService;

    public FoodsController(IFoodService foodService, IUserContentService userContentService)
    {
        _foodService = foodService;
        _userContentService = userContentService;
    }

    [Route("single")]
    [HttpPost]
    public ActionResult<FoodResponse> GetFood([FromBody] FoodRequest request)
    {
        return _foodService.GetFood(request);
    }

    [Route("multiple")]
    [HttpPost]
    public ActionResult<List<ContentResponse>> GetListOfContents([FromBody] FullFoodRequest request)
    {
        var response = _foodService.GetResultOfListFood(request.FoodRequests);

        var userContentDb = new List<UserContentRequest>();
        response.ForEach(row =>
        {
            var item = new UserContentRequest(
                row.SourceType,
                row.OrigUnit,
                row.OrigSourceName,
                row.OrigContent,
                row.StandardContent,
                request.UserId);
            userContentDb.Add(item);
        });

        _userContentService.CreateMultipleUserContent(userContentDb);

        return response;
    }
}