using UA.Data.Enums;

namespace UA.Domain.Models;

public sealed class PatchUserModel
{
    public string Name { get; set; }

    public int? Age { get; set; }

    public string Email { get; set; }

    public IEnumerable<RoleEnum> Roles { get; set; }
}