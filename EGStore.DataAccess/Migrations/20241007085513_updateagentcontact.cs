using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateagentcontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e2bfe5f-2c74-4171-8d1c-922a1b57c9ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e360e098-feec-47d1-a006-6ffa9dec7e84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1a6c7b7-e5ac-4b6c-983e-4de64a1f6963");

            migrationBuilder.AddColumn<string>(
                name: "AgentContact",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e157606-e28e-49fc-b164-cb93a38aed34", null, "Manager", "MANAGER" },
                    { "632ac5ee-9fa3-4c37-9d71-8587230e593d", null, "Admin", "ADMIN" },
                    { "eeabcaea-1a69-499e-ac9e-cac24ba00ec7", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e157606-e28e-49fc-b164-cb93a38aed34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "632ac5ee-9fa3-4c37-9d71-8587230e593d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeabcaea-1a69-499e-ac9e-cac24ba00ec7");

            migrationBuilder.DropColumn(
                name: "AgentContact",
                table: "orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e2bfe5f-2c74-4171-8d1c-922a1b57c9ae", null, "User", "USER" },
                    { "e360e098-feec-47d1-a006-6ffa9dec7e84", null, "Admin", "ADMIN" },
                    { "f1a6c7b7-e5ac-4b6c-983e-4de64a1f6963", null, "Manager", "MANAGER" }
                });
        }
    }
}
