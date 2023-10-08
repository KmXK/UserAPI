using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UA.Application.Services.Interfaces;
using UA.Application.ViewModels.Authentication;
using UA.Infrastructure.Config.Interfaces;

namespace UA.Web.Controllers;

[AllowAnonymous]
public class LoginController : BaseController
{
    private readonly IPrincipalAppService _principalAppService;
    private readonly ISecurityConfig _securityConfig;

    public LoginController(
        IPrincipalAppService principalAppService,
        ISecurityConfig securityConfig)
    {
        _principalAppService = principalAppService;
        _securityConfig = securityConfig;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SignInViewModel viewModel)
    {
        var result = await _principalAppService.ValidateUserAsync(viewModel);

        if (result.ErrorMessage != null)
        {
            return BadRequest(new { error = result.ErrorMessage });
        }
        
        return Ok(new { token = GetJwtToken(result) });
    }

    private string GetJwtToken(LoginResultViewModel loginResult)
    {
        var now = DateTime.Now;
        var nowUnix = DateTimeOffset.UtcNow.ToUniversalTime().ToUnixTimeSeconds();
        var lifetime = TimeSpan.FromSeconds(_securityConfig.UserSessionTimeOutSeconds);

        var claims = new Collection<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, loginResult.UserId.ToString()),
            new(JwtRegisteredClaimNames.Email, loginResult.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, nowUnix.ToString(), ClaimValueTypes.Integer64)
        };

        foreach (var userRole in loginResult.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityConfig.Secret));
        var jwt = new JwtSecurityToken(
            _securityConfig.ValidIssuer,
            _securityConfig.ValidAudience,
            claims,
            now,
            now.Add(lifetime),
            new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}