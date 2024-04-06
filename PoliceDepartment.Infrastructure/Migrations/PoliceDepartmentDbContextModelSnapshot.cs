﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoliceDepartment.Infrastructure.DAL;

#nullable disable

namespace PoliceDepartment.Infrastructure.Migrations
{
    [DbContext(typeof(PoliceDepartmentDbContext))]
    partial class PoliceDepartmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PoliceDepartment.Core.Entities.PoliceOfficer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BadgeNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PoliceOfficer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cf61ea87-7bea-441f-b3ac-5ac02ffc7664"),
                            BadgeNumber = "#-123-436-534",
                            BirthDate = new DateTime(1995, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Bobson",
                            LastName = "Dugnutt",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("d2af3596-fbb1-4dfa-b516-d5d24e8f31ba"),
                            BadgeNumber = "#-123-392-166",
                            BirthDate = new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Sleve",
                            LastName = "McDeichel",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("7413ead0-d04d-44c4-bbdf-e672947403eb"),
                            BadgeNumber = "#-232-767-666",
                            BirthDate = new DateTime(1965, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Rey",
                            LastName = "McSriff",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("2d12b97d-aea6-4f1e-b687-56601ec55c18"),
                            BadgeNumber = "#-896-921-338",
                            BirthDate = new DateTime(1975, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Glenallen",
                            LastName = "Mixon",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("0018c22b-a0e9-40fa-84a8-aabf94703548"),
                            BadgeNumber = "#-766-655-594",
                            BirthDate = new DateTime(1968, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Rawl",
                            LastName = "Chamgerlain",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("b30d8fdb-b2ad-4508-976f-690b6fbd7b9d"),
                            BadgeNumber = "#-778-988-363",
                            BirthDate = new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Kevin",
                            LastName = "Nogilny",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("97be04f8-c99b-47b3-8fdd-387123dd4a63"),
                            BadgeNumber = "#-569-450-729",
                            BirthDate = new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Tony",
                            LastName = "Smherik",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("b11b7f00-f37d-4eae-a090-79d78c3f38ab"),
                            BadgeNumber = "#-454-443-541",
                            BirthDate = new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Willie",
                            LastName = "Dustice",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("239bb004-91d0-4993-b2d4-316866dd1df0"),
                            BadgeNumber = "#-405-341-807",
                            BirthDate = new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Mario",
                            LastName = "McRwlain",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("4e770448-a911-4539-8ecc-971d617ca693"),
                            BadgeNumber = "#-569-541-836",
                            BirthDate = new DateTime(1956, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Todd",
                            LastName = "Bonzalez",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
