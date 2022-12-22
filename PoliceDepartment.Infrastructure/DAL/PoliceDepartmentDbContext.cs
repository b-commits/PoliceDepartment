using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Infrastructure.DAL;

public class PoliceDepartmentDbContext : DbContext
{
    public DbSet<PoliceOfficer> PoliceOfficers { get; set; }
    
    public PoliceDepartmentDbContext(DbContextOptions<PoliceDepartmentDbContext> dbContextOptions) 
        : base(dbContextOptions) 
    {
    }

    public PoliceDepartmentDbContext() : base()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "Server=localhost;Database=dev_police_department;Uid=root;Pwd=root;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}