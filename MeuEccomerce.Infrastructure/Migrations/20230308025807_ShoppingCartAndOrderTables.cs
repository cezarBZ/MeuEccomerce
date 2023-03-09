using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuEccomerce.Infrastructure.Migrations
{
    public partial class ShoppingCartAndOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                schema: "MYE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TotalOrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOrderItems = table.Column<int>(type: "int", nullable: false),
                    OrderSent = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderDelivered = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                schema: "MYE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "MYE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderDetails",
                        column: x => x.OrderId,
                        principalSchema: "MYE",
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_OrderDetails",
                        column: x => x.ProductId,
                        principalSchema: "MYE",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "MYE",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                schema: "MYE",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "MYE");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems",
                schema: "MYE");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "MYE");
        }
    }
}
