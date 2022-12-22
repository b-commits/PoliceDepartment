using PoliceDepartment.Application.Services;
using PoliceDepartment.Infrastructure;
using PoliceDepartment.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddPoliceDepartmentDatabase();
builder.Services.AddScoped<IPoliceOfficerService, PoliceOfficersService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();