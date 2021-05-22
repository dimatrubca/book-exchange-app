using Microsoft.EntityFrameworkCore.Migrations;

namespace BookExchange.IdentityServer.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57909559-a2fa-44ac-beb2-901349f5bf83", "f01d7624-6310-403e-8d48-e42d536ecd56", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc830dc9-c7c6-46c2-b5ac-3cde9e26fb7f", "a2f24acd-465f-4154-8878-69be915036a3", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57909559-a2fa-44ac-beb2-901349f5bf83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc830dc9-c7c6-46c2-b5ac-3cde9e26fb7f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, null, "0dee0a07-01cf-4490-b114-ca23f45103ec", "dimatrubca@gmail.com", false, null, true, null, false, null, null, null, null, null, false, "7b5130b3-1117-4d78-9066-9ab98d9c9c1a", false, "dimatrubca" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, null, "9a8da43b-7632-409d-aa0d-3d270cd9e233", "dimatrubca@outlook.com", false, null, false, null, false, null, null, null, null, null, false, "8c6d7c1b-c422-439e-a76a-141ae786c1a4", false, "testuser" });
        }
    }
}
