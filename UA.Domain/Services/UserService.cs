using UA.Data.Core.Interfaces;
using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Models;
using UA.Domain.Services.Base;
using UA.Domain.Services.Interfaces;
using UA.Domain.Specifications;

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

    public async Task<bool> DoesUserWithEmailExist(string email)
    {
        return await WorkRepository.Exists(UserSpecifications.ForEmail(email));
    }

    public async Task<PageModel<User>> GetListAsync(PageFilterModel<User> pageFilterModel)
    {
        return await WorkRepository.GetPagedListBySpecAsync(
            pageFilterModel,
            UserSpecifications.ForAll());
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await WorkRepository.GetByIdAsync(id);
    }
}