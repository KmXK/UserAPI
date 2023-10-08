namespace UA.Application.ViewModels.Authentication;

public sealed class LoginResultViewModel
{
    public Guid UserId { get; set; }

    public string Email { get; set; }

    public IEnumerable<string> Roles { get; set; }

    public string ErrorMessage { get; set; }
}