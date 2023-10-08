using UA.Domain.Security;

namespace UA.Domain.Services.Interfaces;

public interface IPrincipalService
{
    Task<UserIdentity> GetUserIdentityAsync(Guid id);
}