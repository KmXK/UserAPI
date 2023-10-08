using Microsoft.AspNetCore.Authorization;
using UA.Data.Enums;

namespace UA.Web.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class AuthorizeRole : AuthorizeAttribute
{
    public AuthorizeRole(params RoleEnum[] roles)
    {
        ArgumentNullException.ThrowIfNull(roles, nameof(roles));
        
        Roles = string.Join(",", roles.Select(x => x.ToString()));
    }
}