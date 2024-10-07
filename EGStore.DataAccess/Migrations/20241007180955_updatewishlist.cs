using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatewishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_wishLists_WishListId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_WishListId",
                table: "products");

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
                name: "WishListId",
                table: "products");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "wishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "wishLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ad654ea-4651-4397-b79a-45db6a0b74f0", null, "Manager", "MANAGER" },
                    { "8dfafc02-1b75-492c-8f38-a8e2a2288d26", null, "Admin", "ADMIN" },
                    { "b1e3ff31-bb37-48ce-9cb5-2647daac7162", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_wishLists_ProductId",
                table: "wishLists",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_wishLists_products_ProductId",
                table: "wishLists",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishLists_products_ProductId",
                table: "wishLists");

            migrationBuilder.DropIndex(
                name: "IX_wishLists_ProductId",
                table: "wishLists");

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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "wishLists");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "wishLists");

            migrationBuilder.AddColumn<int>(
                name: "WishListId",
                table: "products",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_products_WishListId",
                table: "products",
                column: "WishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_wishLists_WishListId",
                table: "products",
                column: "WishListId",
                principalTable: "wishLists",
                principalColumn: "Id");
        }
    }
}
