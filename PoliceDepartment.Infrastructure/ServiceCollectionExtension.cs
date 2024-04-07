using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Infrastructure.Auth;
using PoliceDepartment.Infrastructure.DAL;
using PoliceDepartment.Infrastructure.Repositories;

namespace PoliceDepartment.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddPoliceDepartmentDatabase(this IServiceCollection services)
    {
        services.AddDbContext<PoliceDepartmentDbContext>();
        services.AddScoped<IPoliceOfficerRepository, MySqlPoliceOfficerRepository>();
        services.AddScoped<IUserRepository, MySqlUserRepository>();
    }

    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.Get<JwtOptions>();

        services
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Audience = authOptions!.Audience;
                x.IncludeErrorDetails = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authOptions.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SigningKey!))
                };
            });
    }
}