namespace UA.Application.ViewModels;

public class UserListFilterViewModel
{
    public string Name { get; set; }

    public string Email { get; set; }

    public int? Age { get; set; }

    public IEnumerable<string> Roles { get; set; }
}