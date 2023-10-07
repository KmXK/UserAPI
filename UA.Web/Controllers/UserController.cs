using Microsoft.AspNetCore.Mvc;
using UA.Application.Interfaces;

namespace UA.Web.Controllers;

public class UserController : BaseController
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_userAppService.Test(id));
    }
}