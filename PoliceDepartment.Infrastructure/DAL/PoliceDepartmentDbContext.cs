using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Infrastructure.Interceptors;

namespace PoliceDepartment.Infrastructure.DAL;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class PoliceDepartmentDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<PoliceDepartmentDbContext> _logger;
    private readonly ILogger<AuditableEntityInterceptor> _auditLogger;

    public DbSet<PoliceOfficer>? PoliceOfficers { get; init; }

    public PoliceDepartmentDbContext(
        DbContextOptions<PoliceDepartmentDbContext> dbContextOptions, 
        IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger, IWebHostEnvironment environment, 
        ILogger<AuditableEntityInterceptor> auditLogger) 
        : base(dbContextOptions)
    {
        _configuration = configuration;
        _logger = logger;
        _auditLogger = auditLogger;
    }

    public PoliceDepartmentDbContext(IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger, IWebHostEnvironment environment, ILogger<AuditableEntityInterceptor> auditLogger)
    {
        _configuration = configuration;
        _logger = logger;
        _auditLogger = auditLogger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliceOfficer>().ToTable("PoliceOfficer");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionStringSection = "MySQL";

        // TODO Replace this with the `DbContextOptionsBuilder` extension.
        optionsBuilder.AddInterceptors(new AuditableEntityInterceptor(_auditLogger));
        
        var connectionString = _configuration.GetConnectionString(connectionStringSection);

        if (string.IsNullOrEmpty(connectionString))
        {
            _logger.LogWarning("Connection string for {connectionString} could not be found. Please verify appSettings.", 
                connectionString);
            return;
        }
        
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}