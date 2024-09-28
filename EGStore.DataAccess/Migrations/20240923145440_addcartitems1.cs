using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcartitems1 : Migration
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
                name: "CartId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "carts");

            migrationBuilder.CreateTable(
                name: "cartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartItem_carts_CartId",
                        column: x => x.CartId,
                        principalTable: "carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartItem_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "272c38fa-a771-42ef-8e1e-b273ee85bc74", null, "Admin", "ADMIN" },
                    { "2ca33976-cf6e-458a-83a9-b20f9f72eb90", null, "Manager", "MANAGER" },
                    { "728e47da-73a2-43c1-80f7-dcfc3f9ba282", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItem_CartId",
                table: "cartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItem_ProductId",
                table: "cartItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "272c38fa-a771-42ef-8e1e-b273ee85bc74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca33976-cf6e-458a-83a9-b20f9f72eb90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728e47da-73a2-43c1-80f7-dcfc3f9ba282");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "634a7608-7363-44e5-887c-d2a788387461", null, "Manager", "MANAGER" },
                    { "b4c1205b-35c5-45ff-a60c-7ad42a7373ff", null, "Admin", "ADMIN" },
                    { "eaac0cbc-6931-4e00-8a29-93ebfaafcec9", null, "User", "USER" }
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
