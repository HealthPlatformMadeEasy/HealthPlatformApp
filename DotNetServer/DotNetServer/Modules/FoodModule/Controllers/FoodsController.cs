using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;
using DotNetServer.Modules.FoodModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.FoodModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodsController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [Route("single")]
    [HttpPost]
    public ActionResult<FoodResponse> GetFood([FromBody] FoodRequest request)
    {
        return _foodService.GetFood(request);
    }

    [Route("multiple")]
    [HttpPost]
    public ActionResult<List<ContentResponse>> GetListOfContents([FromBody] List<FoodRequest> request)
    {
        return _foodService.GetResultOfListFood(request);
    }
}