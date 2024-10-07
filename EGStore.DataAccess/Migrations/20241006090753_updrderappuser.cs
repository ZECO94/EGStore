using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updrderappuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5414a2f3-fb3a-4697-876f-152965a1e04b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ed183d-dbe9-4e11-b0ff-e71ea9504042");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1eff9e4-8756-4af5-a1be-15d43a5c6b9b");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5414a2f3-fb3a-4697-876f-152965a1e04b", null, "Admin", "ADMIN" },
                    { "72ed183d-dbe9-4e11-b0ff-e71ea9504042", null, "User", "USER" },
                    { "f1eff9e4-8756-4af5-a1be-15d43a5c6b9b", null, "Manager", "MANAGER" }
                });
        }
    }
}
