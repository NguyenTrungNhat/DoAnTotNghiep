using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MobileShop.Core.Migrations
{
    /// <inheritdoc />
    public partial class addcolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6bcb0387-5fae-40be-9233-fa6008d82b44", "c40bca32-53cc-4dfc-9b45-4b2806544d0e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "30da63a8-a26a-45ef-b6df-2299faafbb10", "e05e6d73-b059-452c-bcec-2716a3e499f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "050187a9-169c-46b3-a4c7-2c0dc205d3ea", "e4682ded-e458-4d19-9cce-280864067f47" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "050187a9-169c-46b3-a4c7-2c0dc205d3ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30da63a8-a26a-45ef-b6df-2299faafbb10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bcb0387-5fae-40be-9233-fa6008d82b44");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40bca32-53cc-4dfc-9b45-4b2806544d0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e05e6d73-b059-452c-bcec-2716a3e499f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4682ded-e458-4d19-9cce-280864067f47");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "UserCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "273180a6-5425-4d4f-9e36-788b8e0a1e26", null, "Employee", "EMPLOYEE" },
                    { "aa3aa04b-22c7-45c4-b386-8d4e130f2401", null, "User", "USER" },
                    { "ef2e4d0a-b346-43a0-b9f2-19395235667f", null, "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "48466186-0511-4bb0-8902-993652cc85da", 0, "949d6566-1615-4950-bb56-1498269a24ef", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEH95BYwQoHn5/ZXKMzvN8ovFp1+q808ezIk7y1Jar3eJnJG27HqE8JjeAlEKnWzimg==", null, false, "97f4d1cf-d00b-44c3-9f19-f59b595c4116", false, "user@gmail.com" },
                    { "5b9dda1a-ab2d-46ae-9c50-0c4df41abc89", 0, "08271381-3bd9-4f88-aa2c-fd60bdec1efe", "IdentityUser", "contributor@gmail.com", true, false, null, "CONTRIBUTOR@GMAIL.COM", "CONTRIBUTOR@GMAIL.COM", "AQAAAAIAAYagAAAAEK8q7IcMTQJ6gDEtt29PMYgKThoo9KgrT+LAZzz5QMnc0zH/STtGHAUguzAG8xqPfA==", null, false, "c1430cd2-4b48-46fb-ae8e-1cae914f28f7", false, "contributor@gmail.com" },
                    { "c35fd022-8118-432f-852f-848087c7b72f", 0, "a6a1b23e-a6f1-45a3-8d7a-d6b286351aee", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEG+wWdO+2E0ttyuVrQ6qmTdKe7bRjx9Ejmc3zmOSWF/+JrnETEXCU4JM14BA9q1g5w==", null, false, "19c0ae21-952d-4257-83aa-cf7c27e37779", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "aa3aa04b-22c7-45c4-b386-8d4e130f2401", "48466186-0511-4bb0-8902-993652cc85da" },
                    { "273180a6-5425-4d4f-9e36-788b8e0a1e26", "5b9dda1a-ab2d-46ae-9c50-0c4df41abc89" },
                    { "ef2e4d0a-b346-43a0-b9f2-19395235667f", "c35fd022-8118-432f-852f-848087c7b72f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aa3aa04b-22c7-45c4-b386-8d4e130f2401", "48466186-0511-4bb0-8902-993652cc85da" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "273180a6-5425-4d4f-9e36-788b8e0a1e26", "5b9dda1a-ab2d-46ae-9c50-0c4df41abc89" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ef2e4d0a-b346-43a0-b9f2-19395235667f", "c35fd022-8118-432f-852f-848087c7b72f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "273180a6-5425-4d4f-9e36-788b8e0a1e26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa3aa04b-22c7-45c4-b386-8d4e130f2401");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef2e4d0a-b346-43a0-b9f2-19395235667f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48466186-0511-4bb0-8902-993652cc85da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b9dda1a-ab2d-46ae-9c50-0c4df41abc89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c35fd022-8118-432f-852f-848087c7b72f");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UserCart");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "050187a9-169c-46b3-a4c7-2c0dc205d3ea", null, "Owner", "OWNER" },
                    { "30da63a8-a26a-45ef-b6df-2299faafbb10", null, "Employee", "EMPLOYEE" },
                    { "6bcb0387-5fae-40be-9233-fa6008d82b44", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c40bca32-53cc-4dfc-9b45-4b2806544d0e", 0, "4eebb1b6-536c-4a60-8809-4ae5d14add9e", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEAW+9h20fspo+dIWKtxu5izS0eBndKcmiSWetZ0UtID3VRZJdV7JD9lyk1Ahxh2XZg==", null, false, "7ae9655a-6f17-4eac-aef9-3654048898ab", false, "user@gmail.com" },
                    { "e05e6d73-b059-452c-bcec-2716a3e499f6", 0, "a59cba68-c2c3-4e08-8814-b679efa8bc0f", "IdentityUser", "contributor@gmail.com", true, false, null, "CONTRIBUTOR@GMAIL.COM", "CONTRIBUTOR@GMAIL.COM", "AQAAAAIAAYagAAAAEO6MhpLO1L8fISfu8TIWr+DKVGMUpDb4iw1V8qqcvg6VYkMxIAy07pgAnRSJn0BXXQ==", null, false, "9d52a6af-9185-40f0-b794-c45182d3c0e2", false, "contributor@gmail.com" },
                    { "e4682ded-e458-4d19-9cce-280864067f47", 0, "966d5a42-d601-46a4-a97a-f26595922f35", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJoxwpzjWjm+GW+jKrubHxc9+rCyln3DVLV1/1fbCmHZPPNDCymd9sb3/w4RZ3nOCw==", null, false, "ad831572-181f-4d09-82fe-df3dc992a2c4", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6bcb0387-5fae-40be-9233-fa6008d82b44", "c40bca32-53cc-4dfc-9b45-4b2806544d0e" },
                    { "30da63a8-a26a-45ef-b6df-2299faafbb10", "e05e6d73-b059-452c-bcec-2716a3e499f6" },
                    { "050187a9-169c-46b3-a4c7-2c0dc205d3ea", "e4682ded-e458-4d19-9cce-280864067f47" }
                });
        }
    }
}
