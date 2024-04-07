using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;

namespace PoliceDepartment.Application.Extensions;

public static class MediatrExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(configuration 
            => configuration.RegisterServicesFromAssembly(typeof(MediatrExtensions).Assembly));
        services.AddValidatorsFromAssembly(typeof(CreatePoliceOfficerValidator).Assembly);
    }
}