using Microsoft.Extensions.DependencyInjection;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Infrastructure.DAL;
using PoliceDepartment.Infrastructure.Repositories;

namespace PoliceDepartment.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddPoliceDepartmentDatabase(this IServiceCollection services)
    {
        services.AddDbContext<PoliceDepartmentDbContext>();
        services.AddScoped<IPoliceOfficerRepository, MySqlPoliceOfficerRepository>();
    }
}