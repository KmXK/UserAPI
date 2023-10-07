using UA.Data.Models;

namespace UA.Domain.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetRolesAsync();
}