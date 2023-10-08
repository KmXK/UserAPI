using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Filtering;
using UA.Domain.Models;

namespace UA.Domain.Services.Interfaces;

public interface IUserService
{
    Task<User> Create(UpdateUserModel model);

    Task<bool> DoesUserWithEmailExist(string email, Guid? id = null);
    
    Task<PageModel<User>> GetListAsync(
        PageFilterModel<User> pageFilterModel,
        UserListFilterModel filterModel);

    Task<User> GetUserByIdAsync(Guid id);

    Task<User> UpdateAsync(Guid id, UpdateUserModel model);
    
    Task<User> UpdateAsync(Guid id, PatchUserModel model);
    
    Task<bool> DeleteAsync(Guid id);
    
    Task<User> ValidateUserAsync(string email, string password);
}