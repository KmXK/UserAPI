using UA.Data.Core.Interfaces;
using UA.Data.Models;
using UA.Domain.Models;
using UA.Domain.Services.Base;
using UA.Domain.Services.Interfaces;

namespace UA.Domain.Services;

public sealed class UserService : BaseService<Guid, User>, IUserService
{
    private readonly IRoleService _roleService;

    public UserService(
        IUnitOfWork unitOfWork,
        IRoleService roleService) : base(unitOfWork)
    {
        _roleService = roleService;
    }
    
    public async Task<User> Create(CreateUserModel model)
    {
        var roles = (await _roleService.GetRolesAsync()).ToDictionary(x => x.Id, x => x);
        
        var user = new User
        {
            Age = model.Age,
            Email = model.Email,
            Name = model.Name,
            Roles = model.Roles.Select(x => roles[x]).ToList()
        };

        await WorkRepository.AddAsync(user);

        await UnitOfWork.SaveChangesAsync();

        return user;
    }
}