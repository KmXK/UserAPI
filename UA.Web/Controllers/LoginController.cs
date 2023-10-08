using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Application.Services.Interfaces;
using UA.Application.ViewModels.Authentication;

namespace UA.Web.Controllers;

[AllowAnonymous]
public class LoginController : BaseController
{
    private readonly IPrincipalAppService _principalAppService;

    public LoginController(IPrincipalAppService principalAppService)
    {
        _principalAppService = principalAppService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SignInViewModel viewModel)
    {
        var result = await _principalAppService.ValidateUserAsync(viewModel);

        if (result.ErrorMessage != null)
        {
            return BadRequest(new { error = result.ErrorMessage });
        }
        
        return Ok(result);
    }
}