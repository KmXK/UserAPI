using UA.Application.Services.Interfaces;
using UA.Application.ViewModels.Authentication;
using UA.Domain.Services.Interfaces;

namespace UA.Application.Services;

public sealed class PrincipalAppService : IPrincipalAppService
{
    private readonly IUserService _userService;

    public PrincipalAppService(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<LoginResultViewModel> ValidateUserAsync(SignInViewModel viewModel)
    {
        var user = await _userService.ValidateUserAsync(viewModel.Email, viewModel.Password);

        if (user == null)
        {
            return new LoginResultViewModel
            {
                ErrorMessage = "Invalid user email or password."
            };
        }

        return new LoginResultViewModel
        {
            UserId = user.Id,
            Roles = user.Roles.Select(x => x.Name)
        };
    }
}