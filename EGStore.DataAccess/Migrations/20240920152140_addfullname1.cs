using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addfullname1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "120cea72-eb52-4273-81dd-cf54ed9de1a2", null, "User", "USER" },
                    { "26e9c5cb-ab8c-4253-ade6-12a6d7446909", null, "Admin", "ADMIN" },
                    { "6a9956e1-2b1d-4960-ba6b-25e0e4bb688f", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "120cea72-eb52-4273-81dd-cf54ed9de1a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e9c5cb-ab8c-4253-ade6-12a6d7446909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a9956e1-2b1d-4960-ba6b-25e0e4bb688f");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

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
    }
}
