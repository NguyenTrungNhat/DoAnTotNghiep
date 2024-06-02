using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MobileShop.Core.Migrations
{
    /// <inheritdoc />
    public partial class addnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed7e7c8e-03ff-479e-9266-856303481990", "3dd1026e-e647-4b83-9264-c59f9324113a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf523e74-db85-45f1-af29-4c957f3da6e6", "76dddec9-01ca-4114-b695-23c177896f8c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "052e92a2-9e48-40b7-8549-9523f7e4f976", "85c02ec4-f85c-42ef-b610-76b7125a07fb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "052e92a2-9e48-40b7-8549-9523f7e4f976");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf523e74-db85-45f1-af29-4c957f3da6e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed7e7c8e-03ff-479e-9266-856303481990");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dd1026e-e647-4b83-9264-c59f9324113a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76dddec9-01ca-4114-b695-23c177896f8c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85c02ec4-f85c-42ef-b610-76b7125a07fb");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "UserCart",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Image",
                table: "UserCart");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "052e92a2-9e48-40b7-8549-9523f7e4f976", null, "Employee", "EMPLOYEE" },
                    { "cf523e74-db85-45f1-af29-4c957f3da6e6", null, "Owner", "OWNER" },
                    { "ed7e7c8e-03ff-479e-9266-856303481990", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3dd1026e-e647-4b83-9264-c59f9324113a", 0, "9100bab3-87a1-4870-9d7a-afcf085c7760", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEN+l1QOdN1cwdPczOPeqYxMF3v1U4s5DUWX60mq4jDzNJn6ky0kv4o40GzVDp7h7PA==", null, false, "68bd9c75-a693-4846-b212-9220f14904e8", false, "user@gmail.com" },
                    { "76dddec9-01ca-4114-b695-23c177896f8c", 0, "9f2dd1e7-2799-4681-9d5a-ccd4193bb7c1", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEI+kDoyDMhiixPNHqAl/eyTD6RDG0/uIJoz8kHRRzzqak2bkTlIlsmFOApoP+IgmtQ==", null, false, "4d2a035b-a26a-486a-a3af-89da6f4370c2", false, "admin@gmail.com" },
                    { "85c02ec4-f85c-42ef-b610-76b7125a07fb", 0, "35407952-aaa3-4dc8-952e-9e59b9836f79", "IdentityUser", "contributor@gmail.com", true, false, null, "CONTRIBUTOR@GMAIL.COM", "CONTRIBUTOR@GMAIL.COM", "AQAAAAIAAYagAAAAEDvah9vUnIXgdOrCNv7WY8ATcfx1CjjDRqiagNDbapj7kBIWBTTl095AM1f5QEYgIw==", null, false, "2f5b43a0-1193-4ac2-a6cc-9b6f66fc29ec", false, "contributor@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ed7e7c8e-03ff-479e-9266-856303481990", "3dd1026e-e647-4b83-9264-c59f9324113a" },
                    { "cf523e74-db85-45f1-af29-4c957f3da6e6", "76dddec9-01ca-4114-b695-23c177896f8c" },
                    { "052e92a2-9e48-40b7-8549-9523f7e4f976", "85c02ec4-f85c-42ef-b610-76b7125a07fb" }
                });
        }
    }
}
