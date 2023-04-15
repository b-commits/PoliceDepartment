using Microsoft.AspNetCore.Builder;

namespace PoliceDepartment.Infrastructure;

public static class WebBuilderExtensions
{
    public static void ConfigureSwagger(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseSwagger();
        applicationBuilder.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            options.RoutePrefix = string.Empty;
        });
    }
}