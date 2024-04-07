using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PoliceDepartment.Application.Security;

namespace PoliceDepartment.Infrastructure.Auth;

internal sealed class Authenticator(
    IConfiguration configuration,
    TimeProvider timeProvider)
    : IAuthenticator
{
    public JwtDto CreateToken(string email, string role)
    {
        var options = new AuthOptions();
        
        configuration.GetSection(AuthOptions.OptionsKey).Bind(options);
        
        var now = timeProvider.GetLocalNow().DateTime;
        var expires = options.Expiry is not null ? 
            now.Add(options.Expiry.Value) : 
            now.Add(TimeSpan.FromHours(5));

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey)), SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.UniqueName, email),
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Role, role)
        };

        var jwtSecurityToken = new JwtSecurityToken(
            options.Issuer, 
            options.Audience, 
            claims, 
            expires: expires,
            signingCredentials: signingCredentials, 
            notBefore: now);

        return new JwtDto
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        };

    }
}