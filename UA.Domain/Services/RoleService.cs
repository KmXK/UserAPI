using UA.Data.Core.Interfaces;
using UA.Data.Enums;
using UA.Data.Models;
using UA.Domain.Services.Base;
using UA.Domain.Services.Interfaces;

namespace UA.Domain.Services;

public sealed class RoleService : BaseService<RoleEnum, Role>, IRoleService
{
    public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        return await WorkRepository.GetAllAsync();
    }
}