using DotNetServer.Modules.NorwegianFoodModule.Entities;
using DotNetServer.Modules.NorwegianFoodModule.Model.Requests;
using DotNetServer.Modules.NorwegianFoodModule.Model.Responses;
using DotNetServer.Modules.NorwegianFoodModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.NorwegianFoodModule.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class NorwegianFoodsController : ControllerBase
{
    private readonly INorwegianFoodService _norwegianFoodService;

    public NorwegianFoodsController(INorwegianFoodService norwegianFoodService)
    {
        _norwegianFoodService = norwegianFoodService;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<NorwegianFood> GetNorwegianFoodById(Guid id)
    {
        return Ok(_norwegianFoodService.GetNorwegianFoodById(id));
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<ActionResult<NorwegianFoodResponse>> GetTotalResultOfNorwegianFood(
        [FromQuery] NorwegianFoodRequest request)
    {
        var response = await _norwegianFoodService.GetNorwegianFoodByName(request);

        return Ok(response.Data);
    }
}