using UA.Application.ViewModels.Authentication;

namespace UA.Application.Services.Interfaces;

public interface IPrincipalAppService
{
    Task<LoginResultViewModel> ValidateUserAsync(SignInViewModel viewModel);
}