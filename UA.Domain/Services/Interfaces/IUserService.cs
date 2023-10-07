using UA.Data.Models;
using UA.Domain.Models;

namespace UA.Domain.Services.Interfaces;

public interface IUserService
{
    Task<User> Create(CreateUserModel model);

    Task<bool> DoesUserWithEmailExist(string email);
}