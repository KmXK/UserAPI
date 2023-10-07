using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Models;

namespace UA.Domain.Services.Interfaces;

public interface IUserService
{
    Task<User> Create(CreateUserModel model);

    Task<bool> DoesUserWithEmailExist(string email);
    
    Task<PageModel<User>> GetListAsync(PageFilterModel<User> pageFilterModel);

    Task<User> GetUserByIdAsync(Guid id);
}