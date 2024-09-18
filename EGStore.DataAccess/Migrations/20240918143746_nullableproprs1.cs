using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nullableproprs1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c29d4d6-5515-4e05-9b3f-d13768af531a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e02e33bc-f31a-4bce-a2c9-43437fe69a0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3cb1b15-0286-4767-ba24-73e035962049");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e89a355-0c46-4190-9462-0693c95e6488", null, "Admin", "ADMIN" },
                    { "b4d23322-8976-4630-9905-b2938c25e3dc", null, "User", "USER" },
                    { "c86934c0-4523-45eb-9277-85eb07f83a94", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e89a355-0c46-4190-9462-0693c95e6488");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d23322-8976-4630-9905-b2938c25e3dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86934c0-4523-45eb-9277-85eb07f83a94");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c29d4d6-5515-4e05-9b3f-d13768af531a", null, "User", "USER" },
                    { "e02e33bc-f31a-4bce-a2c9-43437fe69a0c", null, "Admin", "ADMIN" },
                    { "f3cb1b15-0286-4767-ba24-73e035962049", null, "Manager", "MANAGER" }
                });
        }
    }
}
