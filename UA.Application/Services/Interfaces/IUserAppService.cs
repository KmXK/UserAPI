using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;

namespace UA.Application.Services.Interfaces;

public interface IUserAppService
{
    Task<UserViewModel> Create(UpdateUserViewModel viewModel, Guid currentUserId);

    Task<PageViewModel<UserViewModel>> GetListAsync(
        PageFilterViewModel pageFilterViewModel,
        UserListFilterViewModel filterViewModel);

    Task<UserViewModel> GetUserByIdAsync(Guid id);

    Task<UserViewModel> UpdateAsync(Guid id, UpdateUserViewModel viewModel, Guid currentUserId);

    Task<UserViewModel> UpdateAsync(Guid id, PatchUserViewModel viewModel, Guid currentUserId);

    Task<bool> DeleteAsync(Guid id, Guid currentUserId);
}