using UA.Data.Core.Interfaces;
using UA.Data.Models;
using UA.Domain.Models;
using UA.Domain.Services.Base;
using UA.Domain.Services.Interfaces;

namespace UA.Domain.Services;

public sealed class UserService : BaseService<Guid, User>, IUserService
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    
    public async Task<User> Create(CreateUserModel model)
    {
        var user = new User
        {
            Age = model.Age,
            Email = model.Email,
            Name = model.Name,
            Roles = model.Roles.Select(x => new Role { Id = x }).ToList()
        };

        await WorkRepository.AddAsync(user);

        await UnitOfWork.SaveChangesAsync();

        return user;
    }
}