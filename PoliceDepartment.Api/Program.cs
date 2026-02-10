using PoliceDepartment.Application.Extensions;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Infrastructure;
using PoliceDepartment.Infrastructure.Middleware;
using PoliceDepartment.Infrastructure.Security;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Host.UseSerilog((_, loggerConfiguration) =>
{
    loggerConfiguration
        .WriteTo.Console()
        .WriteTo.File("./pdlog.log");
});

builder.Services.AddControllers();
builder.Services.AddSecurity();
builder.Services.AddAuth(configuration);
builder.Services.AddInterceptors();
builder.Services.AddProblemDetails();
builder.Services.AddMediator();
builder.Services.AddPoliceDepartmentDatabase();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddScoped<IPoliceOfficerService, PoliceOfficersService>();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.ConfigureSwagger();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

await app.RunAsync();


