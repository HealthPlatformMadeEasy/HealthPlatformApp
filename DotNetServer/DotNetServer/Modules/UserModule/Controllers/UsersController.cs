using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.UserModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<User> GetUser(Guid id)
    {
        return Ok(_userService.GetUser(id));
    }
}