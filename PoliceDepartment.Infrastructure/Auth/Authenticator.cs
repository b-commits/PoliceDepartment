using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PoliceDepartment.Application.Security;

namespace PoliceDepartment.Infrastructure.Auth;

internal sealed class Authenticator : IAuthenticator
{
    private readonly IConfiguration configuration;
    private readonly TimeProvider timeProvider;
    private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

    public Authenticator(
        IConfiguration configuration, 
        TimeProvider timeProvider, 
        JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        this.configuration = configuration;
        this.timeProvider = timeProvider;
        this.jwtSecurityTokenHandler = jwtSecurityTokenHandler;
    }

    public JwtDto CreateToken(string email, string role)
    {
        var authOptions = configuration.Get<JwtOptions>();
        var now = timeProvider.GetUtcNow().Date;
        var expires = now.Add(authOptions.Expiry.Value).Date;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SigningKey)),
            SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.UniqueName, email),
            new(ClaimTypes.Role, role)
        };

        var jwt = new JwtSecurityToken(authOptions.Issuer, authOptions.Audience, claims, expires: expires,
            signingCredentials: signingCredentials, notBefore: now);

        return new JwtDto
        {
            AccessToken = jwtSecurityTokenHandler.WriteToken(jwt)
        };

    }
}