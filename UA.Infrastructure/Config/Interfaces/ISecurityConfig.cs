namespace UA.Infrastructure.Config.Interfaces;

public interface ISecurityConfig
{
    public string Secret { get; }

    public int UserSessionTimeOutSeconds { get; set; }

    public string ValidIssuer { get; set; }

    public string ValidAudience { get; set; }
}