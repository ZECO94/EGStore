using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcartoptions1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_carts_CartId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CartId",
                table: "products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f0b7c62-6ddc-49a6-a4a9-0ac726848cc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "735bd7b6-7e48-48d1-90e4-caa5ba94b613");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f337c8d7-3bbc-4abe-90e1-408932463cd8");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f6322fc-fc93-4ad0-a48d-3209f597fe23", null, "Admin", "ADMIN" },
                    { "94419666-392a-4401-91f0-822b234d1851", null, "User", "USER" },
                    { "a31cb3f7-d5ec-47b1-a53f-a09d692a0c79", null, "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_ProductId",
                table: "carts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_ProductId",
                table: "carts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_ProductId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_ProductId",
                table: "carts");

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

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f0b7c62-6ddc-49a6-a4a9-0ac726848cc1", null, "User", "USER" },
                    { "735bd7b6-7e48-48d1-90e4-caa5ba94b613", null, "Manager", "MANAGER" },
                    { "f337c8d7-3bbc-4abe-90e1-408932463cd8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CartId",
                table: "products",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_carts_CartId",
                table: "products",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id");
        }
    }
}
