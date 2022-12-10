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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Database=Dev;Uid=root;Pwd=root;");
    }
}