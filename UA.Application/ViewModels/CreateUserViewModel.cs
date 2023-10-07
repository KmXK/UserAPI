using UA.Data.Enums;

namespace UA.Application.ViewModels;

public sealed class CreateUserViewModel
{
    public int Age { get; set; }
    
    public string Email { get; set; }

    public IEnumerable<RoleEnum> Roles { get; set; }
}