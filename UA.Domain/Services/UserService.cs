using UA.Data.Models;
using UA.Domain.Models;
using UA.Domain.Services.Interfaces;

namespace UA.Domain.Services;

public sealed class UserService : IUserService
{
    public Task<User> Create(CreateUserModel model)
    {
        throw new NotImplementedException();
    }
}