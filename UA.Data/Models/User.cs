using System.Collections.ObjectModel;
using UA.Data.Models.Base;

namespace UA.Data.Models;

public class User : Entity<Guid>
{
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Email { get; set; }

    public Collection<Role> Roles { get; set; } = new();
}