using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoliceDepartment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("08ab9053-3ebc-415c-9c4f-9adee66b5795"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("0e08e9d6-3c91-4d5a-b94d-dbd900c66683"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("1ba457c8-207c-4dfc-88c3-4f7df7526c9b"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("36d00338-d72f-41a7-aef3-48746f4c2285"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("39dbfbdc-c8b9-466e-a1d8-b9dfb25bff8d"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("5429ebb9-6ef1-44c9-af9f-8f57400218cd"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("6795ef05-cc0c-4fb4-891f-b44da081ecfd"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("acb9d742-1dfc-4f43-bd3d-98c041fb44f0"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("af9e4a52-4046-4a90-ae1a-d968fb17ec05"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("bef86b91-7eda-4f38-97c0-6557ff1b396f"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "PoliceOfficer",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "PoliceOfficer",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "PoliceOfficer");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "PoliceOfficer");

            migrationBuilder.InsertData(
                table: "PoliceOfficer",
                columns: new[] { "Id", "BadgeNumber", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("08ab9053-3ebc-415c-9c4f-9adee66b5795"), "#-778-988-363", new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", "Nogilny" },
                    { new Guid("0e08e9d6-3c91-4d5a-b94d-dbd900c66683"), "#-454-443-541", new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willie", "Dustice" },
                    { new Guid("1ba457c8-207c-4dfc-88c3-4f7df7526c9b"), "#-896-921-338", new DateTime(1975, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glenallen", "Mixon" },
                    { new Guid("36d00338-d72f-41a7-aef3-48746f4c2285"), "#-123-392-166", new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleve", "McDeichel" },
                    { new Guid("39dbfbdc-c8b9-466e-a1d8-b9dfb25bff8d"), "#-232-767-666", new DateTime(1965, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rey", "McSriff" },
                    { new Guid("5429ebb9-6ef1-44c9-af9f-8f57400218cd"), "#-123-436-534", new DateTime(1995, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bobson", "Dugnutt" },
                    { new Guid("6795ef05-cc0c-4fb4-891f-b44da081ecfd"), "#-569-541-836", new DateTime(1956, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Todd", "Bonzalez" },
                    { new Guid("acb9d742-1dfc-4f43-bd3d-98c041fb44f0"), "#-766-655-594", new DateTime(1968, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rawl", "Chamgerlain" },
                    { new Guid("af9e4a52-4046-4a90-ae1a-d968fb17ec05"), "#-569-450-729", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tony", "Smherik" },
                    { new Guid("bef86b91-7eda-4f38-97c0-6557ff1b396f"), "#-405-341-807", new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "McRwlain" }
                });
        }
    }
}
