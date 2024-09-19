using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2d102b0d-7da8-406a-a012-b51a0d98b8ee", null, "Admin", "ADMIN" },
                    { "5b781c13-441c-4f97-81d9-86ed5cd9c077", null, "Manager", "MANAGER" },
                    { "f286dd1f-b2d1-4e28-b2c2-b1fe8e62e824", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2a02a70f-5fe1-4c62-b028-d6003f48477d", null, "Admin", "ADMIN" },
                    { "5fb1a574-eb90-4872-8527-7c064e36b063", null, "User", "USER" },
                    { "f13efe20-d123-4830-8a61-35a24eb8f252", null, "Manager", "MANAGER" }
                });
        }
    }
}
