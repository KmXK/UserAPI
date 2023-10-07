using UA.Application.ViewModels;

namespace UA.Application.Services.Interfaces;

public interface IUserAppService
{
    Task<UserViewModel> Create(CreateUserViewModel viewModel);
}