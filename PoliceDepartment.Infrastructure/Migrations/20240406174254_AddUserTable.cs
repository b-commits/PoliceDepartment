using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoliceDepartment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("0018c22b-a0e9-40fa-84a8-aabf94703548"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("239bb004-91d0-4993-b2d4-316866dd1df0"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("2d12b97d-aea6-4f1e-b687-56601ec55c18"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("4e770448-a911-4539-8ecc-971d617ca693"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("7413ead0-d04d-44c4-bbdf-e672947403eb"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("97be04f8-c99b-47b3-8fdd-387123dd4a63"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("b11b7f00-f37d-4eae-a090-79d78c3f38ab"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("b30d8fdb-b2ad-4508-976f-690b6fbd7b9d"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("cf61ea87-7bea-441f-b3ac-5ac02ffc7664"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("d2af3596-fbb1-4dfa-b516-d5d24e8f31ba"));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PoliceOfficer",
                columns: new[] { "Id", "BadgeNumber", "BirthDate", "Created", "FirstName", "LastName", "Modified" },
                values: new object[,]
                {
                    { new Guid("10344b85-1b85-4117-bd08-e1fa3e874650"), "#-569-450-729", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tony", "Smherik", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("11a3501f-3626-4dcf-acf9-b580d94c955f"), "#-405-341-807", new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mario", "McRwlain", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7c8625b5-c783-47e8-aa56-929b06142962"), "#-766-655-594", new DateTime(1968, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Rawl", "Chamgerlain", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7d68e63e-32d5-4dc4-ad34-5902e29142a0"), "#-123-392-166", new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sleve", "McDeichel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8b267d27-9278-4704-b7c0-01f56c407bce"), "#-454-443-541", new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Willie", "Dustice", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8bdb23d3-ae1b-4ef2-8c77-27a83a02304a"), "#-232-767-666", new DateTime(1965, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Rey", "McSriff", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9bf33505-5554-493a-ba92-50206e0d0e05"), "#-123-436-534", new DateTime(1995, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bobson", "Dugnutt", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d0b3f4c8-0411-4169-a69a-37883ddda421"), "#-778-988-363", new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Kevin", "Nogilny", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e51d5552-6751-40e8-ae07-b98fe99f4275"), "#-896-921-338", new DateTime(1975, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Glenallen", "Mixon", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e97de61e-74f5-4ea5-819f-4b4d3defd60a"), "#-569-541-836", new DateTime(1956, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Todd", "Bonzalez", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("10344b85-1b85-4117-bd08-e1fa3e874650"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("11a3501f-3626-4dcf-acf9-b580d94c955f"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("7c8625b5-c783-47e8-aa56-929b06142962"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("7d68e63e-32d5-4dc4-ad34-5902e29142a0"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("8b267d27-9278-4704-b7c0-01f56c407bce"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("8bdb23d3-ae1b-4ef2-8c77-27a83a02304a"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("9bf33505-5554-493a-ba92-50206e0d0e05"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("d0b3f4c8-0411-4169-a69a-37883ddda421"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("e51d5552-6751-40e8-ae07-b98fe99f4275"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("e97de61e-74f5-4ea5-819f-4b4d3defd60a"));

            migrationBuilder.InsertData(
                table: "PoliceOfficer",
                columns: new[] { "Id", "BadgeNumber", "BirthDate", "Created", "FirstName", "LastName", "Modified" },
                values: new object[,]
                {
                    { new Guid("0018c22b-a0e9-40fa-84a8-aabf94703548"), "#-766-655-594", new DateTime(1968, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Rawl", "Chamgerlain", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("239bb004-91d0-4993-b2d4-316866dd1df0"), "#-405-341-807", new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mario", "McRwlain", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2d12b97d-aea6-4f1e-b687-56601ec55c18"), "#-896-921-338", new DateTime(1975, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Glenallen", "Mixon", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4e770448-a911-4539-8ecc-971d617ca693"), "#-569-541-836", new DateTime(1956, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Todd", "Bonzalez", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7413ead0-d04d-44c4-bbdf-e672947403eb"), "#-232-767-666", new DateTime(1965, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Rey", "McSriff", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("97be04f8-c99b-47b3-8fdd-387123dd4a63"), "#-569-450-729", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tony", "Smherik", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b11b7f00-f37d-4eae-a090-79d78c3f38ab"), "#-454-443-541", new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Willie", "Dustice", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b30d8fdb-b2ad-4508-976f-690b6fbd7b9d"), "#-778-988-363", new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Kevin", "Nogilny", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cf61ea87-7bea-441f-b3ac-5ac02ffc7664"), "#-123-436-534", new DateTime(1995, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bobson", "Dugnutt", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d2af3596-fbb1-4dfa-b516-d5d24e8f31ba"), "#-123-392-166", new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sleve", "McDeichel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }
    }
}
