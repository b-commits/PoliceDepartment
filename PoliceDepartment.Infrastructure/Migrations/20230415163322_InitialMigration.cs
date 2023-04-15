using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliceDepartment.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoliceOfficers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BadgeNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceOfficers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PoliceOfficers",
                columns: new[] { "Id", "BadgeNumber", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0c51a7c4-e1b1-4c76-8613-e4d052c6ef8b"), "#-454-443-541", new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willie", "Dustice" },
                    { new Guid("26fe312c-32ae-47f4-a6a1-554ccb68bdd7"), "#-766-655-594", new DateTime(1968, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rawl", "Chamgerlain" },
                    { new Guid("32c75a28-ef4e-4b5f-972a-4a5aa057d985"), "#-569-450-729", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tony", "Smherik" },
                    { new Guid("48720644-6130-4744-81ed-1528d01cd617"), "#-778-988-363", new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", "Nogilny" },
                    { new Guid("50e4dc59-b8b4-4500-a81c-27f95c64af17"), "#-569-541-836", new DateTime(1956, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Todd", "Bonzalez" },
                    { new Guid("6f0e19ee-8c7c-4624-af7c-7c6eed8cea05"), "#-232-767-666", new DateTime(1965, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rey", "McSriff" },
                    { new Guid("76f47e29-60ed-469c-9336-64623ef5f2f0"), "#-896-921-338", new DateTime(1975, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glenallen", "Mixon" },
                    { new Guid("7d0ee9be-bdd7-462d-8152-0e1f2d887b2c"), "#-123-392-166", new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleve", "McDeichel" },
                    { new Guid("97d09b2b-263c-4f2e-9559-a3332e8e50d8"), "#-405-341-807", new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "McRwlain" },
                    { new Guid("d0b6cd5c-6547-48f8-bd6c-50d2d48f7ed9"), "#-123-436-534", new DateTime(1995, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bobson", "Dugnutt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliceOfficers");
        }
    }
}
