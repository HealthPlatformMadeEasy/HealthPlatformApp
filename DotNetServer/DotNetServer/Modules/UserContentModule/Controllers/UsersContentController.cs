using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;
using DotNetServer.Modules.UserContentModule.Services;
using DotNetServer.Modules.UserModule.Model.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetServer.Modules.UserContentModule.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
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
    public ActionResult<UserContentResponse> GetUserContentById(Guid id)
    {
        return _userContentService.GetUserContent(id);
    }

    [Route("get-macros-and-energy/{id:guid}")]
    [HttpGet]
    public ActionResult<MacrosAndEnergyResponse> GetMacrosAndEnergy(Guid id)
    {
        return _userContentService.GetMacrosAndEnergy(id);
    }

    [HttpPost]
    public ActionResult<UserResponse> PostUserContent([FromBody] UserContentRequest userContentRequest)
    {
        var validator = _validator.Validate(userContentRequest);

        if (!validator.IsValid) return BadRequest(validator.Errors);

        if (_userContentService.CreateUserContent(userContentRequest))
            return CreatedAtAction("GetUserContentById", new { id = userContentRequest.Id }, userContentRequest);

        return BadRequest();
    }

    [Route("multiple")]
    [HttpPost]
    public ActionResult PostMultipleUserContent([FromBody] List<UserContentRequest> userContentRequests)
    {
        _userContentService.CreateMultipleUserContent(userContentRequests);
        return Ok();
    }

    [Route("user-id/{id:guid}")]
    [HttpGet]
    public ActionResult<List<UserContentResponse>> GetUsersContentByUserId(Guid id)
    {
        return Ok(_userContentService.GetUserContentByUserId(id));
    }
}