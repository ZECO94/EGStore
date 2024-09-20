using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04efe03f-97f1-4655-bdca-48d9761fd0e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b9929c2-5e80-4ba0-8cb6-6f810905217f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ff25ab-4be1-40ee-a28f-d3fe37b4fa37");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "04efe03f-97f1-4655-bdca-48d9761fd0e6", null, "Admin", "ADMIN" },
                    { "2b9929c2-5e80-4ba0-8cb6-6f810905217f", null, "User", "USER" },
                    { "a5ff25ab-4be1-40ee-a28f-d3fe37b4fa37", null, "Manager", "MANAGER" }
                });
        }
    }
}
