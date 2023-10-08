using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Filtering;
using UA.Domain.Models;
using UA.Domain.Security;

namespace UA.Domain.Services.Interfaces;

public interface IUserService
{
    Task<User> Create(UpdateUserModel model, UserIdentity userIdentity);

    Task<bool> DoesUserWithEmailExist(string email, Guid? id = null);

    Task<PageModel<User>> GetListAsync(
        PageFilterModel<User> pageFilterModel,
        UserListFilterModel filterModel);

    Task<User> GetUserByIdAsync(Guid id);

    Task<User> UpdateAsync(Guid id, UpdateUserModel model, UserIdentity userIdentity);

    Task<User> UpdateAsync(Guid id, PatchUserModel model, UserIdentity userIdentity);

    Task<bool> DeleteAsync(Guid id, UserIdentity userIdentity);

    Task<User> ValidateUserAsync(string email, string password);
}