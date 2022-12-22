using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Infrastructure.DAL;

public static class PoliceDepartmentDbSeeder
{
    internal static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliceOfficer>().HasData(new List<PoliceOfficer>()
        {
            new(Guid.NewGuid(), "Bobson", "Dugnutt", new BirthDate(new DateOnly(1995, 1, 18)), "#-123-436-534"),
            new(Guid.NewGuid(), "Sleve", "McDeichel", new BirthDate(new DateOnly(1985, 12, 13)), "#-123-392-166"),
            new(Guid.NewGuid(), "Rey", "McSriff", new BirthDate(new DateOnly(1965, 6, 23)), "#-232-767-666"),
            new(Guid.NewGuid(), "Glenallen", "Mixon", new BirthDate(new DateOnly(1975, 8, 24)), "#-896-921-338"),
            new(Guid.NewGuid(), "Rawl", "Chamgerlain", new BirthDate(new DateOnly(1968, 11, 26)), "#-766-655-594"),
            new(Guid.NewGuid(), "Kevin", "Nogilny", new BirthDate(new DateOnly(1986, 1, 21)), "#-778-988-363"),
            new(Guid.NewGuid(), "Tony", "Smherik", new BirthDate(new DateOnly(1982, 3, 3)), "#-569-450-729"),
            new(Guid.NewGuid(), "Willie", "Dustice", new BirthDate(new DateOnly(1973, 5, 11)), "#-454-443-541"),
            new(Guid.NewGuid(), "Mario", "McRwlain", new BirthDate(new DateOnly(1995, 6, 18)), "#-405-341-807"),
            new(Guid.NewGuid(), "Todd", "Bonzalez", new BirthDate(new DateOnly(1956, 7, 18)), "#-569-541-836"),
        });
    }
}