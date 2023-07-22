using DotNetServer.Model.Requests;
using DotNetServer.Model.Responses;
using DotNetServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Controllers;

[ApiController]
[Route("/v1/api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
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