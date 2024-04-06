using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoliceDepartment.Infrastructure.Migrations
{
    public partial class RenamePoliceOfficerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PoliceOfficers",
                newName: "PoliceOfficer");
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliceOfficers",
                table: "PoliceOfficer");

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("0c51a7c4-e1b1-4c76-8613-e4d052c6ef8b"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("26fe312c-32ae-47f4-a6a1-554ccb68bdd7"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("32c75a28-ef4e-4b5f-972a-4a5aa057d985"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("48720644-6130-4744-81ed-1528d01cd617"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("50e4dc59-b8b4-4500-a81c-27f95c64af17"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("6f0e19ee-8c7c-4624-af7c-7c6eed8cea05"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("76f47e29-60ed-469c-9336-64623ef5f2f0"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("7d0ee9be-bdd7-462d-8152-0e1f2d887b2c"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("97d09b2b-263c-4f2e-9559-a3332e8e50d8"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("d0b6cd5c-6547-48f8-bd6c-50d2d48f7ed9"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliceOfficer",
                table: "PoliceOfficer",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliceOfficer",
                table: "PoliceOfficer");

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

            migrationBuilder.RenameTable(
                name: "PoliceOfficer",
                newName: "PoliceOfficers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliceOfficers",
                table: "PoliceOfficers",
                column: "Id");

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
    }
}
