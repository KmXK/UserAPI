using UA.Application.ViewModels;

namespace UA.Application.Interfaces;

public interface IUserAppService
{
    Task<UserViewModel> Create(CreateUserViewModel viewModel);
}