using UA.Data.Models;

namespace UA.Application.ViewModels;

public sealed class UserViewModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Email { get; set; }
    
    public IEnumerable<Role> Roles { get; set; }
}