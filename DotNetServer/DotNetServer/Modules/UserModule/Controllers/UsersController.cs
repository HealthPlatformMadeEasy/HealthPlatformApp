using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;
using DotNetServer.Modules.UserModule.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.UserModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<UserRequest> _userValidator;

    public UsersController(IUserService userService, IValidator<UserRequest> userValidator)
    {
        _userService = userService;
        _userValidator = userValidator;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<User> GetUser(Guid id)
    {
        return Ok(_userService.GetUser(id));
    }

    [HttpPost]
    public ActionResult<UserResponse> PostUser([FromBody] UserRequest userRequest)
    {
        var validator = _userValidator.Validate(userRequest);

        if (!validator.IsValid) return Conflict(validator.Errors);
        _userService.CreateUser(userRequest);

        return CreatedAtAction("GetUser", new { id = userRequest.Id }, userRequest);
    }
}