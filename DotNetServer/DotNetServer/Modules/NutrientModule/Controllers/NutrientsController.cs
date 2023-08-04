using DotNetServer.Modules.NutrientModule.Model.Requests;
using DotNetServer.Modules.NutrientModule.Model.Responses;
using DotNetServer.Modules.NutrientModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.NutrientModule.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class NutrientsController : ControllerBase
{
    private readonly INutrientService _nutrientService;

    public NutrientsController(INutrientService nutrientService)
    {
        _nutrientService = nutrientService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<NutrientResponse>> GetNutrientById(Guid id)
    {
        var response = await _nutrientService.GetNutrientByIdAsync(id);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<NutrientResponse>> PostNutrient([FromBody] NutrientRequest request)
    {
        try
        {
            await _nutrientService.AddNutrientAsync(request);

            return CreatedAtAction("GetNutrientById", new { id = request.Id }, request);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteNutrient(Guid id)
    {
        try
        {
            await _nutrientService.DeleteNutrientAsync(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("energy-macros/{id:guid}")]
    public async Task<ActionResult<EnergyAndMacroResponse>> GetEnergyAndMacros(Guid id)
    {
        var response = await _nutrientService.GetEnergyAndMacros(id);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }
}