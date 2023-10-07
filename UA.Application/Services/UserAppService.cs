using UA.Application.Interfaces;
using UA.Application.ViewModels;

namespace UA.Application.Services;

internal sealed class UserAppService : IUserAppService
{
    public Task<UserViewModel> Create(CreateUserViewModel viewModel)
    {
        throw new NotImplementedException();
    }
}