using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Infrastructure.DAL;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class PoliceDepartmentDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<PoliceDepartmentDbContext> _logger;
    private readonly IWebHostEnvironment _environment;

    public DbSet<PoliceOfficer>? PoliceOfficers { get; set; }

    public PoliceDepartmentDbContext(
        DbContextOptions<PoliceDepartmentDbContext> dbContextOptions, 
        IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger, IWebHostEnvironment environment) 
        : base(dbContextOptions)
    {
        _environment = environment;
        _configuration = configuration;
        _logger = logger;
    }

    public PoliceDepartmentDbContext(IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger, IWebHostEnvironment environment)
    {
        _environment = environment;
        _configuration = configuration;
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliceOfficer>().ToTable("PoliceOfficer");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionStringSection = "MySQL";
        
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