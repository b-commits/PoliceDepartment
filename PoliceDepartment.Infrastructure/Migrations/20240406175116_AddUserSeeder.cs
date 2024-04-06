using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PoliceDepartment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("089fd97d-3927-4b3b-a1b9-0303db7aab2e"), "#-766-655-594", new DateTime(1968, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Rawl", "Chamgerlain", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("22ba7186-07f0-4c8e-b349-9ef4444746e5"), "#-778-988-363", new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Kevin", "Nogilny", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("41a9bf24-e6fd-485f-9f08-a9bdf0dece29"), "#-123-436-534", new DateTime(1995, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bobson", "Dugnutt", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("544c98a9-9cd9-4256-909f-8b5bf4d18cf0"), "#-569-450-729", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tony", "Smherik", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("98cf4f55-2571-4fa2-b3ec-a7689bba14ca"), "#-896-921-338", new DateTime(1975, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Glenallen", "Mixon", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b859a6c9-542a-4ca5-acae-dd0e5e853d24"), "#-454-443-541", new DateTime(1973, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Willie", "Dustice", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb345f59-dfb0-4969-b9e0-514fc2296842"), "#-232-767-666", new DateTime(1965, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Rey", "McSriff", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d1d6b88b-d39e-4c6e-ae5a-5beddf6ba9d3"), "#-123-392-166", new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sleve", "McDeichel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eead03ab-a818-4cda-86b4-afc9eef4ca7a"), "#-405-341-807", new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mario", "McRwlain", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f81aee23-a299-4cd8-bb0c-7266fd90709d"), "#-569-541-836", new DateTime(1956, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Todd", "Bonzalez", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "Email", "Modified", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("80c7fffa-3d45-4bd3-b96d-a0bce878e6cb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@nypd.com", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "aa3493434alpha9991111233435", "Admin", "admin" },
                    { new Guid("80c7fffa-3d45-4bd3-b96d-a0bce878e6cd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "reviewer@nypd.com", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "aa3493434beta9991111233435", "Reviewer", "reviewer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("089fd97d-3927-4b3b-a1b9-0303db7aab2e"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("22ba7186-07f0-4c8e-b349-9ef4444746e5"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("41a9bf24-e6fd-485f-9f08-a9bdf0dece29"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("544c98a9-9cd9-4256-909f-8b5bf4d18cf0"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("98cf4f55-2571-4fa2-b3ec-a7689bba14ca"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("b859a6c9-542a-4ca5-acae-dd0e5e853d24"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("cb345f59-dfb0-4969-b9e0-514fc2296842"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("d1d6b88b-d39e-4c6e-ae5a-5beddf6ba9d3"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("eead03ab-a818-4cda-86b4-afc9eef4ca7a"));

            migrationBuilder.DeleteData(
                table: "PoliceOfficer",
                keyColumn: "Id",
                keyValue: new Guid("f81aee23-a299-4cd8-bb0c-7266fd90709d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("80c7fffa-3d45-4bd3-b96d-a0bce878e6cb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("80c7fffa-3d45-4bd3-b96d-a0bce878e6cd"));

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
    }
}
