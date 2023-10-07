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
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UpdateUserViewModel viewModel)
    {
        var user = await _userAppService.Create(viewModel);
        return Ok(user);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateUserViewModel viewModel)
    {
        var user = await _userAppService.UpdateAsync(id, viewModel);
        return Ok(user);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] PatchUserViewModel viewModel)
    {
        var user = await _userAppService.UpdateAsync(id, viewModel);
        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _userAppService.DeleteAsync(id);
        return result ? Ok() : NotFound();
    }
}