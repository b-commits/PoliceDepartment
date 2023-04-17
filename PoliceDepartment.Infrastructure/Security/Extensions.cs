using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartment.Application.Security;

namespace PoliceDepartment.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<string>, PasswordHasher<string>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}