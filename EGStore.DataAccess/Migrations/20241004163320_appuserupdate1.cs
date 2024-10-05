using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class appuserupdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4178d50b-fae5-49e0-8a52-f0c6c9ceee1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1f46ee1-01ff-470b-badd-26fc3c15c1ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d93117a8-1919-45dc-a60e-d34810a26d9c");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Street",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4178d50b-fae5-49e0-8a52-f0c6c9ceee1b", null, "User", "USER" },
                    { "b1f46ee1-01ff-470b-badd-26fc3c15c1ff", null, "Admin", "ADMIN" },
                    { "d93117a8-1919-45dc-a60e-d34810a26d9c", null, "Manager", "MANAGER" }
                });
        }
    }
}
