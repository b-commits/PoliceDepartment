using PoliceDepartment.Application.Services;
using PoliceDepartment.Infrastructure.DAL;
using PoliceDepartment.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPoliceOfficerService, PoliceOfficersService>();
builder.Services.AddDbContext<PoliceDepartmentDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();