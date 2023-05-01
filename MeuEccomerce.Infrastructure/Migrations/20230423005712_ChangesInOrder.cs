using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuEccomerce.Infrastructure.Migrations
{
    public partial class ChangesInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address2",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Endereco",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                schema: "MYE",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "MYE",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "MYE",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginDate",
                schema: "MYE",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "MYE",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Order",
                schema: "MYE",
                table: "Order",
                column: "CustomerId",
                principalSchema: "MYE",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Order",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "MYE",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "MYE",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "MYE",
                table: "Order",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "MYE",
                table: "Order",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                schema: "MYE",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginDate",
                schema: "MYE",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
