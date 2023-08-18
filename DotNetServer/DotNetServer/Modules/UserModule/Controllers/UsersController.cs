using DotNetServer.Core.Context;
using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;
using DotNetServer.Modules.UserModule.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.UserModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    private readonly NorwegianFoodDbContext _db;
    private readonly IValidator<MinimalUserRequest> _minimalValidator;
    private readonly IUserService _userService;
    private readonly IValidator<UserRequest> _userValidator;

    public UsersController(IUserService userService, IValidator<UserRequest> userValidator,
        IValidator<MinimalUserRequest> minimalValidator, NorwegianFoodDbContext db)
    {
        _userService = userService;
        _userValidator = userValidator;
        _minimalValidator = minimalValidator;
        _db = db;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> GetUserAsync(Guid id)
    {
        var response = await _userService.GetUserAsync(id);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }

    [Route("get-user-id")]
    [HttpGet]
    public async Task<ActionResult<UserIdResponse>> GetUserIdAsync([FromQuery] MinimalUserRequest minimalUserRequest)
    {
        var response = await _userService.GetUserIdAsync(minimalUserRequest);

        if (response.Succeeded) return Ok(response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UserIdResponse>> PostUserAsync([FromBody] MinimalUserRequest minimalUserRequest)
    {
        var validator = await _minimalValidator.ValidateAsync(minimalUserRequest);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        var response = await _userService.AddUserAsync(minimalUserRequest);

        if (response.Succeeded)
            return CreatedAtAction("GetUser", new { id = response.Data.UserId }, response.Data);

        if (response.Errors is not null) return BadRequest(response.Errors);

        return BadRequest();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUserAsync(Guid id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UserResponse>> UpdateUserAsync(Guid id, [FromBody] UserRequest userRequest)
    {
        var validator = await _userValidator.ValidateAsync(userRequest);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        try
        {
            await _userService.UpdateUserAsync(id, userRequest);

            return Ok(userRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("test")]
    [HttpPost]
    public ActionResult TestPost([FromBody] User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();

        return Ok();
    }
}