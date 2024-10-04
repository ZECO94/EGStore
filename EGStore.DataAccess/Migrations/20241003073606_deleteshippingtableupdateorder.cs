using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteshippingtableupdateorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_shippings_ShippingId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "shippings");

            migrationBuilder.DropIndex(
                name: "IX_orders_ShippingId",
                table: "orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dac9a04-f69b-497b-a3a7-9dd21ec22801");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37f16c0b-52d9-48a3-a693-edd79fff822b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de49b003-ac5d-4893-901f-b089a7a48de1");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveringAgent",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "PaymentDueDate",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingDate",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
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
                    { "4178d50b-fae5-49e0-8a52-f0c6c9ceee1b", null, "User", "USER" },
                    { "b1f46ee1-01ff-470b-badd-26fc3c15c1ff", null, "Admin", "ADMIN" },
                    { "d93117a8-1919-45dc-a60e-d34810a26d9c", null, "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_OrderId",
                table: "carts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OrderId",
                table: "carts",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OrderId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_OrderId",
                table: "carts");

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
                name: "Address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "DeliveringAgent",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "shippings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dac9a04-f69b-497b-a3a7-9dd21ec22801", null, "Manager", "MANAGER" },
                    { "37f16c0b-52d9-48a3-a693-edd79fff822b", null, "Admin", "ADMIN" },
                    { "de49b003-ac5d-4893-901f-b089a7a48de1", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShippingId",
                table: "orders",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_shippings_ShippingId",
                table: "orders",
                column: "ShippingId",
                principalTable: "shippings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
