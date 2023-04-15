using Microsoft.Extensions.DependencyInjection;

namespace PoliceDepartment.Application.Extensions;

public static class MediatrExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg 
            => cfg.RegisterServicesFromAssembly(typeof(MediatrExtensions).Assembly));
    }
}