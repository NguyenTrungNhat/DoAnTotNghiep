using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MobileShop.Core.Migrations
{
    /// <inheritdoc />
    public partial class newinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCart_AspNetUsers_UserId",
                table: "UserCart");

            migrationBuilder.DropIndex(
                name: "IX_UserCart_UserId",
                table: "UserCart");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ebb9ea96-86f4-4753-b4d4-69e3b9051953", "6b9f6c1b-8e26-42ae-9fe3-27c4e321e555" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a70ba378-a675-48c6-bde4-307b267fa18c", "bd8a9ce8-3ad8-43b1-b75d-b94b538a7f41" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d254e768-d36c-4a05-90dd-0329239d1541", "cfc5b9c4-1be1-4895-ad8f-39a3ad0e5cf9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a70ba378-a675-48c6-bde4-307b267fa18c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d254e768-d36c-4a05-90dd-0329239d1541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebb9ea96-86f4-4753-b4d4-69e3b9051953");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b9f6c1b-8e26-42ae-9fe3-27c4e321e555");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd8a9ce8-3ad8-43b1-b75d-b94b538a7f41");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc5b9c4-1be1-4895-ad8f-39a3ad0e5cf9");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCart",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCartId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserCartId",
                table: "AspNetUsers",
                column: "UserCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserCart_UserCartId",
                table: "AspNetUsers",
                column: "UserCartId",
                principalTable: "UserCart",
                principalColumn: "UserCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserCart_UserCartId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserCartId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "UserCartId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a70ba378-a675-48c6-bde4-307b267fa18c", null, "User", "USER" },
                    { "d254e768-d36c-4a05-90dd-0329239d1541", null, "Employee", "EMPLOYEE" },
                    { "ebb9ea96-86f4-4753-b4d4-69e3b9051953", null, "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6b9f6c1b-8e26-42ae-9fe3-27c4e321e555", 0, "3768aab4-acb7-434b-b497-2fc447565563", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJZBtl+SL2R5cnHMVw+NIr3Go1B8ItGHa6abXJI+SUm88ewHlHEacWmfGK0wT8bEEg==", null, false, "68b899c2-e08c-4766-a97c-fe575fec5790", false, "admin@gmail.com" },
                    { "bd8a9ce8-3ad8-43b1-b75d-b94b538a7f41", 0, "a7a96290-5f14-49bc-b8a9-9f1f9bbf610e", "IdentityUser", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEBRBNIQNpbpfw6FWSxsKoglSZr1exf8a3gza0qUf5L4UH7cTy3IBR/AbXM0sJRiQNg==", null, false, "8a43ed3b-3b00-4a86-9178-fa12fc99ab3f", false, "user@gmail.com" },
                    { "cfc5b9c4-1be1-4895-ad8f-39a3ad0e5cf9", 0, "769bf6ca-41ba-47af-a025-08f8058cbdb4", "IdentityUser", "contributor@gmail.com", true, false, null, "CONTRIBUTOR@GMAIL.COM", "CONTRIBUTOR@GMAIL.COM", "AQAAAAIAAYagAAAAELW9sPXlvo3N3GNckkBK2HhSHaPJTxsNPktqEJwsy58q/7QcAmhmDanm2pVR1jcJwQ==", null, false, "7d3d9cae-3b69-4b6b-a2fc-ebf99269f9e7", false, "contributor@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ebb9ea96-86f4-4753-b4d4-69e3b9051953", "6b9f6c1b-8e26-42ae-9fe3-27c4e321e555" },
                    { "a70ba378-a675-48c6-bde4-307b267fa18c", "bd8a9ce8-3ad8-43b1-b75d-b94b538a7f41" },
                    { "d254e768-d36c-4a05-90dd-0329239d1541", "cfc5b9c4-1be1-4895-ad8f-39a3ad0e5cf9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCart_UserId",
                table: "UserCart",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCart_AspNetUsers_UserId",
                table: "UserCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
