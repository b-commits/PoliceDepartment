using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Infrastructure.Helpers;
using PoliceDepartment.Infrastructure.Interceptors;

namespace PoliceDepartment.Infrastructure.DAL;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
internal class PoliceDepartmentDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<PoliceDepartmentDbContext> _logger;
    private readonly ILogger<AuditableEntityInterceptor> _auditLogger;
    private readonly IWebHostEnvironment _environment;

    public DbSet<PoliceOfficer>? PoliceOfficers { get; init; }
    public DbSet<User>? Users { get; init; }

    public PoliceDepartmentDbContext(
        DbContextOptions<PoliceDepartmentDbContext> dbContextOptions, 
        IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger, 
        IWebHostEnvironment environment, 
        ILogger<AuditableEntityInterceptor> auditLogger) 
        : base(dbContextOptions)
    {
        _configuration = configuration;
        _logger = logger;
        _environment = environment;
        _auditLogger = auditLogger;
    }

    public PoliceDepartmentDbContext(IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger, 
        IWebHostEnvironment environment, 
        ILogger<AuditableEntityInterceptor> auditLogger)
    {
        _configuration = configuration;
        _logger = logger;
        _environment = environment;
        _auditLogger = auditLogger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliceOfficer>().ToTable("PoliceOfficer");
        modelBuilder.Entity<User>().ToTable("User").Property(e => e.Role).HasColumnType("nvarchar(30)");
        
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionStringSection = "MySQL";
        
        optionsBuilder.AddInterceptors(new AuditableEntityInterceptor(_auditLogger));

        var connection = _environment.IsProduction()
            ? AzureOnPremiseMySqlConnectionStringNormalizer.Normalize(Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb"))
            : _configuration.GetConnectionString(connectionStringSection);

        _logger.LogInformation("{name} is {connectionString}.", 
            nameof(connection), connection);
        
        if (string.IsNullOrEmpty(connection))
        {
            _logger.LogWarning("Connection string for {connectionString} could not be found. Please verify the appSettings.", 
                connection);
            return;
        }
        
        optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
}