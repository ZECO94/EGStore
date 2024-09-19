using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2a02a70f-5fe1-4c62-b028-d6003f48477d", null, "Admin", "ADMIN" },
                    { "5fb1a574-eb90-4872-8527-7c064e36b063", null, "User", "USER" },
                    { "f13efe20-d123-4830-8a61-35a24eb8f252", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a02a70f-5fe1-4c62-b028-d6003f48477d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fb1a574-eb90-4872-8527-7c064e36b063");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f13efe20-d123-4830-8a61-35a24eb8f252");

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
    }
}
