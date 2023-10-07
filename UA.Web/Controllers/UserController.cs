using Microsoft.AspNetCore.Mvc;
using UA.Application.Interfaces;
using UA.Application.ViewModels;

namespace UA.Web.Controllers;

public class UserController : BaseController
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel viewModel)
    {
        var user = await _userAppService.Create(viewModel);
        return Ok(user);
    }
}