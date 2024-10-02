using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatecart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f6322fc-fc93-4ad0-a48d-3209f597fe23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94419666-392a-4401-91f0-822b234d1851");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a31cb3f7-d5ec-47b1-a53f-a09d692a0c79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dac9a04-f69b-497b-a3a7-9dd21ec22801", null, "Manager", "MANAGER" },
                    { "37f16c0b-52d9-48a3-a693-edd79fff822b", null, "Admin", "ADMIN" },
                    { "de49b003-ac5d-4893-901f-b089a7a48de1", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dac9a04-f69b-497b-a3a7-9dd21ec22801");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37f16c0b-52d9-48a3-a693-edd79fff822b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de49b003-ac5d-4893-901f-b089a7a48de1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f6322fc-fc93-4ad0-a48d-3209f597fe23", null, "Admin", "ADMIN" },
                    { "94419666-392a-4401-91f0-822b234d1851", null, "User", "USER" },
                    { "a31cb3f7-d5ec-47b1-a53f-a09d692a0c79", null, "Manager", "MANAGER" }
                });
        }
    }
}
