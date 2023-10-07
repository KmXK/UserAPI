using UA.Data.Enums;
using UA.Data.Models.Base;

namespace UA.Data.Models;

public sealed class Role : Entity<RoleEnum>
{
    public string Name { get; set; }
}