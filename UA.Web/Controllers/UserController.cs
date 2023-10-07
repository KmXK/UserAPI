using Microsoft.AspNetCore.Mvc;
using UA.Application.Services.Interfaces;
using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;

namespace UA.Web.Controllers;

public class UserController : BaseController
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PageFilterViewModel pageFilterViewModel)
    {
        var user = await _userAppService.GetListAsync(pageFilterViewModel);
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel viewModel)
    {
        var user = await _userAppService.Create(viewModel);
        return Ok(user);
    }
}