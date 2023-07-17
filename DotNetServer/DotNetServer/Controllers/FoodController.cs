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

    [HttpPost]
    public ActionResult<FoodResponse> GetFood([FromBody] FoodRequest request)
    {
        return _foodService.GetFood(request);
    }
}