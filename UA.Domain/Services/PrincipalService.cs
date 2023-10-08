using UA.Domain.Security;
using UA.Domain.Services.Interfaces;

namespace UA.Domain.Services;

public class PrincipalService : IPrincipalService
{
    private readonly IUserService _userService;

    public PrincipalService(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<UserIdentity> GetUserIdentityAsync(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        return new UserIdentity
        {
            Id = id,
            Roles = user.Roles.Select(x => x.Id).ToList()
        };
    }
}