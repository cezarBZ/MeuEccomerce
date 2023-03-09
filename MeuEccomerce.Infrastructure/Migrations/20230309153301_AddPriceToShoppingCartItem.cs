using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuEccomerce.Infrastructure.Migrations
{
    public partial class AddPriceToShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderDetails",
                schema: "MYE",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "MYE",
                table: "OrderDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "MYE",
                table: "ShoppingCartItems",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                schema: "MYE",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "MYE",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                schema: "MYE",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "MYE",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderDetails",
                schema: "MYE",
                table: "OrderDetails",
                column: "OrderId",
                principalSchema: "MYE",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
