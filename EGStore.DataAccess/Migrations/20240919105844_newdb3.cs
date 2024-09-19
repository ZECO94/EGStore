using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newdb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d102b0d-7da8-406a-a012-b51a0d98b8ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b781c13-441c-4f97-81d9-86ed5cd9c077");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f286dd1f-b2d1-4e28-b2c2-b1fe8e62e824");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2d102b0d-7da8-406a-a012-b51a0d98b8ee", null, "Admin", "ADMIN" },
                    { "5b781c13-441c-4f97-81d9-86ed5cd9c077", null, "Manager", "MANAGER" },
                    { "f286dd1f-b2d1-4e28-b2c2-b1fe8e62e824", null, "User", "USER" }
                });
        }
    }
}
