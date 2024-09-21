using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addphoto1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bedcde2-2b72-4272-aaea-6ff187886128");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d7e5541-f589-4b63-b96e-708c2ae13fe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e29a68-f26e-42ea-887a-44b0937c68f4");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "634a7608-7363-44e5-887c-d2a788387461", null, "Manager", "MANAGER" },
                    { "b4c1205b-35c5-45ff-a60c-7ad42a7373ff", null, "Admin", "ADMIN" },
                    { "eaac0cbc-6931-4e00-8a29-93ebfaafcec9", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "634a7608-7363-44e5-887c-d2a788387461");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4c1205b-35c5-45ff-a60c-7ad42a7373ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaac0cbc-6931-4e00-8a29-93ebfaafcec9");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bedcde2-2b72-4272-aaea-6ff187886128", null, "User", "USER" },
                    { "9d7e5541-f589-4b63-b96e-708c2ae13fe8", null, "Admin", "ADMIN" },
                    { "f1e29a68-f26e-42ea-887a-44b0937c68f4", null, "Manager", "MANAGER" }
                });
        }
    }
}
