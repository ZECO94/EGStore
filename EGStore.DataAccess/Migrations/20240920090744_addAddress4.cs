using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAddress4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f51691c-dece-4c16-a627-703b19997ed9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8703750a-573a-4806-895d-6c183f7aeebf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae8022f-3eec-4809-b457-74e078b76dbd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4df865a5-07cb-43ea-98fb-fb83dab460f9", null, "Admin", "ADMIN" },
                    { "a92ad5c4-3d51-4895-bcf3-14974e6d55e5", null, "Manager", "MANAGER" },
                    { "be83fb1c-6f46-4306-bb2f-e86a3f04c635", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df865a5-07cb-43ea-98fb-fb83dab460f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92ad5c4-3d51-4895-bcf3-14974e6d55e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be83fb1c-6f46-4306-bb2f-e86a3f04c635");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f51691c-dece-4c16-a627-703b19997ed9", null, "Manager", "MANAGER" },
                    { "8703750a-573a-4806-895d-6c183f7aeebf", null, "Admin", "ADMIN" },
                    { "dae8022f-3eec-4809-b457-74e078b76dbd", null, "User", "USER" }
                });
        }
    }
}
