using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Infrastructure.DAL;

internal sealed class PoliceOfficerConfiguration : IEntityTypeConfiguration<PoliceOfficer>
{
    public void Configure(EntityTypeBuilder<PoliceOfficer> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.BadgeNumber)
            .HasConversion(x => x.Value, x => new BadgeNumber(x));
        builder.Property(x => x.BirthDate)
            .HasConversion(x => x.Value,
                x => new BirthDate(x));
    }
}