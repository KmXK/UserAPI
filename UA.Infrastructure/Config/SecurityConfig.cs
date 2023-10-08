using UA.Infrastructure.Config.Interfaces;

namespace UA.Infrastructure.Config;

public class SecurityConfig : ISecurityConfig
{
    public string Secret { get; set; }
}