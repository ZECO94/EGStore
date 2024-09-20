using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removephoneno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
