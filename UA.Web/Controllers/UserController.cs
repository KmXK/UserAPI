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
    public async Task<IActionResult> List(
        [FromQuery] PageFilterViewModel pageFilterViewModel,
        [FromQuery, Bind(Prefix = "filterSettings")] UserListFilterViewModel filterViewModel)
    {
        var user = await _userAppService.GetListAsync(pageFilterViewModel, filterViewModel);
        return Ok(user);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _userAppService.GetUserByIdAsync(id);
        return user != null ? Ok(user) : NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UpdateUserViewModel viewModel)
    {
        var user = await _userAppService.Create(viewModel, UserId);
        return Ok(user);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateUserViewModel viewModel)
    {
        var user = await _userAppService.UpdateAsync(id, viewModel, UserId);
        return Ok(user);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] PatchUserViewModel viewModel)
    {
        var user = await _userAppService.UpdateAsync(id, viewModel, UserId);
        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _userAppService.DeleteAsync(id, UserId);
        return result ? Ok() : NotFound();
    }
}