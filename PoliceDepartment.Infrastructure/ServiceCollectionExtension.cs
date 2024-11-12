using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Infrastructure.Auth;
using PoliceDepartment.Infrastructure.DAL;
using PoliceDepartment.Infrastructure.Decorators;
using PoliceDepartment.Infrastructure.Repositories;

namespace PoliceDepartment.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddPoliceDepartmentDatabase(this IServiceCollection services)
    {
        services.AddDbContext<PoliceDepartmentDbContext>();
        services.AddScoped<IPoliceOfficerRepository, MySqlPoliceOfficerRepository>();
        services.AddScoped<IUnitOfWork, MySqlUnitOfWork>();
        services.AddScoped<IUserRepository, MySqlUserRepository>();

        services.Decorate(typeof(IRequestHandler<,>), typeof(RequestHandlerUnitOfWorkDecorator<,>));
    }

    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new AuthOptions();
        var azureAd = new AzureAuthOptions();
        
        configuration.GetSection(AuthOptions.OptionsKey).Bind(options);

        services
            .AddScoped<ICurrentUserService, CurrentUserService>()
            .AddHttpContextAccessor()
            .AddSingleton<JwtSecurityTokenHandler>()
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
        
        services.AddMicrosoftIdentityWebApiAuthentication(configuration);
        services.AddAuthorization();
    }
}