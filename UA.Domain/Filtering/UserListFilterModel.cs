namespace UA.Domain.Filtering;

public class UserListFilterModel
{
    public string Name { get; set; }

    public string Email { get; set; }
    
    public int Age { get; set; }
    
    public IEnumerable<RoleFilterModel> Roles { get; set; }
}