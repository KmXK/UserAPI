namespace UA.Application.ViewModels.Authentication;

public sealed class LoginResultViewModel
{
    public Guid UserId { get; set; }
    
    public IEnumerable<string> Roles { get; set; }
    
    public string ErrorMessage { get; set; }
}