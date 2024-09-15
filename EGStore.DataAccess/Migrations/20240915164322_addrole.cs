using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21a30c17-47e9-47c5-bf04-a474eb744a6a", null, "Manager", "MANAGER" },
                    { "3ab78b4b-4cd4-4768-8fec-81468d0ddadb", null, "User", "USER" },
                    { "750424c3-e5f7-4b1b-8f10-44c597523a51", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21a30c17-47e9-47c5-bf04-a474eb744a6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ab78b4b-4cd4-4768-8fec-81468d0ddadb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "750424c3-e5f7-4b1b-8f10-44c597523a51");
        }
    }
}
