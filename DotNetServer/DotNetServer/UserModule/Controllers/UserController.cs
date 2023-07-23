using DotNetServer.UserModule.Entities;
using DotNetServer.UserModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.UserModule.Controllers;

[ApiController]
[Route("/v1/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("/{id:guid}")]
    public ActionResult<User> GetUser(Guid id)
    {
        return Ok(_userService.GetUser(id));
    }
}