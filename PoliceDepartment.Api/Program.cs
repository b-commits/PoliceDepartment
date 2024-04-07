using PoliceDepartment.Application.Extensions;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Infrastructure;
using PoliceDepartment.Infrastructure.Middleware;
using PoliceDepartment.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddSecurity();
builder.Services.AddAuth(configuration);
builder.Services.AddInterceptors();
builder.Services.AddProblemDetails();
builder.Services.AddPoliceDepartmentDatabase();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddScoped<IPoliceOfficerService, PoliceOfficersService>();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddMediator();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureSwagger();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


