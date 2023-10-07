using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;

namespace UA.Application.Services.Interfaces;

public interface IUserAppService
{
    Task<UserViewModel> Create(UpdateUserViewModel viewModel);
    
    Task<PageViewModel<UserViewModel>> GetListAsync(
        PageFilterViewModel pageFilterViewModel,
        UserListFilterViewModel filterViewModel);

    Task<UserViewModel> GetUserByIdAsync(Guid id);

    Task<UserViewModel> UpdateAsync(Guid id, UpdateUserViewModel viewModel);
    
    Task<UserViewModel> UpdateAsync(Guid id, PatchUserViewModel viewModel);
    
    Task<bool> DeleteAsync(Guid id);
}