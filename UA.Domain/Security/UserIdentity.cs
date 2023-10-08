using UA.Data.Enums;

namespace UA.Domain.Security;

public sealed class UserIdentity
{
    public Guid Id { get; set; }
    
    public IEnumerable<RoleEnum> Roles { get; set; }

    public bool IsInRole(RoleEnum role)
    {
        return Roles.Contains(role);
    }
}