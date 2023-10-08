using UA.Infrastructure.Config.Interfaces;

namespace UA.Infrastructure.Config;

public class SecurityConfig : ISecurityConfig
{
    public string Secret { get; set; }
    
    public int UserSessionTimeOutSeconds { get; set; }
    
    public string ValidIssuer { get; set; }
    
    public string ValidAudience { get; set; }
}