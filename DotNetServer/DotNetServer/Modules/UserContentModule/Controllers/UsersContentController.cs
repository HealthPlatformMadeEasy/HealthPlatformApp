using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;
using DotNetServer.Modules.UserContentModule.Services;
using DotNetServer.Modules.UserModule.Model.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.UserContentModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
[ApiVersion("1.0")]
public class UsersContentController : ControllerBase
{
    private readonly IUserContentService _userContentService;
    private readonly IValidator<UserContentRequest> _validator;

    public UsersContentController(IUserContentService userContentService, IValidator<UserContentRequest> validator)
    {
        _userContentService = userContentService;
        _validator = validator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserContentResponse>> GetUserContentByIdAsync(Guid id)
    {
        var response = await _userContentService.GetUserContentAsync(id);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }

    [Route("get-macros-and-energy/{id:guid}")]
    [HttpGet]
    public async Task<ActionResult<MacrosAndEnergyResponse>> GetMacrosAndEnergyAsync(Guid id)
    {
        var response = await _userContentService.GetMacrosAndEnergyAsync(id);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> PostUserContentAsync([FromBody] UserContentRequest userContentRequest)
    {
        var validator = await _validator.ValidateAsync(userContentRequest);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        try
        {
            await _userContentService.AddUserContentAsync(userContentRequest);

            return CreatedAtAction("GetUserContentById", new { id = userContentRequest.Id }, userContentRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("multiple")]
    [HttpPost]
    public async Task<ActionResult> PostMultipleUserContentAsync(
        [FromBody] List<UserContentRequest> userContentRequests)
    {
        try
        {
            await _userContentService.AddMultipleUserContentAsync(userContentRequests);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("user-id/{id:guid}")]
    [HttpGet]
    public async Task<ActionResult<List<UserContentResponse>>> GetUsersContentByUserIdAsync(Guid id)
    {
        var response = await _userContentService.GetUserContentByUserIdAsync(id);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }
}