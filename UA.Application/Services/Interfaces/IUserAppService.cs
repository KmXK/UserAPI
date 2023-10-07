using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;

namespace UA.Application.Services.Interfaces;

public interface IUserAppService
{
    Task<UserViewModel> Create(CreateUserViewModel viewModel);
    
    Task<PageViewModel<UserViewModel>> GetListAsync(PageFilterViewModel pageFilterViewModel);
}