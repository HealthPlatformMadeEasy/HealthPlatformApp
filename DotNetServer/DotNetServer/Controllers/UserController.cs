using DotNetServer.Context;
using DotNetServer.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Controllers;

[ApiController]
[Route("/v1/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly FoodbContext _context;

    public UserController(FoodbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<User> GetUser()
    {
        return _context.Users.ToList();
    }
}