using UA.Data.Enums;
using UA.Data.Models.Base;

namespace UA.Data.Models;

public class UserRole : Entity
{
    public Guid UserId { get; set; }

    public RoleEnum RoleId { get; set; }
}