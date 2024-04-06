// ReSharper disable UnusedMethodReturnValue.Global

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Infrastructure.Interceptors;

namespace PoliceDepartment.Infrastructure.Security;

public static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<string>, PasswordHasher<string>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }

    public static IServiceCollection AddInterceptors(this IServiceCollection services)
    {
        services.AddSingleton<AuditableEntityInterceptor>();
        return services;
    }
    
}