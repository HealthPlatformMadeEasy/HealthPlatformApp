using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;
using DotNetServer.Modules.UserModule.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.UserModule.Controllers;

//TODO Refactor this controller, more error checking.
[ApiController]
[Route("v1/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IValidator<MinimalUserRequest> _minimalValidator;
    private readonly IUserService _userService;
    private readonly IValidator<UserRequest> _userValidator;

    public UsersController(IUserService userService, IValidator<UserRequest> userValidator,
        IValidator<MinimalUserRequest> minimalValidator)
    {
        _userService = userService;
        _userValidator = userValidator;
        _minimalValidator = minimalValidator;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<User> GetUser(Guid id)
    {
        return Ok(_userService.GetUser(id));
    }

    [Route("get-user-id")]
    [HttpGet]
    public ActionResult<UserIdResponse> GetUserId([FromQuery] MinimalUserRequest minimalUserRequest)
    {
        try
        {
            return _userService.GetUserId(minimalUserRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public ActionResult<UserIdResponse> PostUser([FromBody] MinimalUserRequest minimalUserRequest)
    {
        var validator = _minimalValidator.Validate(minimalUserRequest);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        var response = _userService.CreateUser(minimalUserRequest);

        return CreatedAtAction("GetUser", new { id = response.UserId }, response);
    }

    [HttpDelete]
    public ActionResult DeleteUser(Guid id)
    {
        _userService.DeleteUser(id);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<UserResponse> UpdateUser(Guid id, [FromBody] UserRequest userRequest)
    {
        var validator = _userValidator.Validate(userRequest);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        if (_userService.UpdateUser(id, userRequest)) return Ok(userRequest);

        return BadRequest();
    }
}