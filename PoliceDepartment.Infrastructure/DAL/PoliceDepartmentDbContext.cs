using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Infrastructure.DAL;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class PoliceDepartmentDbContext : DbContext
{
    private readonly IConfiguration configuration;
    private readonly ILogger<PoliceDepartmentDbContext> logger;

    public DbSet<PoliceOfficer>? PoliceOfficers { get; set; }

    public PoliceDepartmentDbContext(
        DbContextOptions<PoliceDepartmentDbContext> dbContextOptions, 
        IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger) 
        : base(dbContextOptions)
    {
        this.configuration = configuration;
        this.logger = logger;
    }

    public PoliceDepartmentDbContext(IConfiguration configuration, 
        ILogger<PoliceDepartmentDbContext> logger)
    {
        this.configuration = configuration;
        this.logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliceOfficer>().ToTable("PoliceOfficer");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionStringSection = "MySQL";
        
        var connectionString = configuration.GetConnectionString(connectionStringSection);

        if (string.IsNullOrEmpty(connectionString))
        {
            logger.LogWarning($"Connection string for {connectionString} could not be found. Please verify appSettings.");
            return;
        }
        
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}