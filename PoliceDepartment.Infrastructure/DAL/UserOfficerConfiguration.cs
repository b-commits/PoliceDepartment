using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Enums;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Infrastructure.DAL;

internal sealed class UserOfficerConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Role).HasColumnType("nvarchar(30)");
        builder.Property(x => x.Username)
            .HasConversion(x => x.Value,
                x => new Username(x));

        var converter = new EnumToStringConverter<UserRole>();
        builder.Property(x => x.Role).HasConversion(converter);
    }
}