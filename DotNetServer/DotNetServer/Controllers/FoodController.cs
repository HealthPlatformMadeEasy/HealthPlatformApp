using DotNetServer.Entities;
using DotNetServer.Model;
using DotNetServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Controllers;

[ApiController]
[Route("/v1/api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodRepository _foodRepository;

    public FoodController(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    [HttpPost]
    public ActionResult<Food> GetFood([FromBody] FoodRequest request)
    {
        return _foodRepository.GetFood(request.Food);
    }
}
