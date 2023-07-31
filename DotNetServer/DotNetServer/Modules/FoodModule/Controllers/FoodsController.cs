using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;
using DotNetServer.Modules.FoodModule.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.FoodModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly IValidator<FoodRequest> _validatorFood;
    private readonly IValidator<FullFoodRequest> _validatorFull;

    public FoodsController(IFoodService foodService,
        IValidator<FullFoodRequest> validatorFull, IValidator<FoodRequest> validatorFood)
    {
        _foodService = foodService;
        _validatorFull = validatorFull;
        _validatorFood = validatorFood;
    }

    [Route("single")]
    [HttpPost]
    public async Task<ActionResult<FoodResponse>> GetFood([FromBody] FoodRequest request)
    {
        var validator = await _validatorFood.ValidateAsync(request);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        var response = await _foodService.GetFood(request);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }

    [Route("multiple")]
    [HttpPost]
    public async Task<ActionResult<List<ContentResponse>>> GetListOfContents([FromBody] FullFoodRequest request)
    {
        var validator = await _validatorFull.ValidateAsync(request);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        var response = await _foodService.GetContentAndAddToUserContent(request);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }
}