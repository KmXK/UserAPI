using UA.Application.Interfaces;

namespace UA.Application.Services;

internal sealed class UserAppService : IUserAppService
{
    public string Test(Guid id)
    {
        return $"Test string: {id}";
    }
}