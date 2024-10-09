using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatereviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ad654ea-4651-4397-b79a-45db6a0b74f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dfafc02-1b75-492c-8f38-a8e2a2288d26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1e3ff31-bb37-48ce-9cb5-2647daac7162");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f1d7e4a-ec8b-4431-a3b1-17b613747b34", null, "Admin", "ADMIN" },
                    { "6acf2729-a998-4d21-bd8a-fc5c24fe2134", null, "Manager", "MANAGER" },
                    { "ba9b08a5-7002-4f71-b589-27adc12c99b0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f1d7e4a-ec8b-4431-a3b1-17b613747b34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6acf2729-a998-4d21-bd8a-fc5c24fe2134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9b08a5-7002-4f71-b589-27adc12c99b0");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "reviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ad654ea-4651-4397-b79a-45db6a0b74f0", null, "Manager", "MANAGER" },
                    { "8dfafc02-1b75-492c-8f38-a8e2a2288d26", null, "Admin", "ADMIN" },
                    { "b1e3ff31-bb37-48ce-9cb5-2647daac7162", null, "User", "USER" }
                });
        }
    }
}
