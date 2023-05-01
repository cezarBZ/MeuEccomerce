using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuEccomerce.Infrastructure.Migrations
{
    public partial class AddCustomFieldsToUsers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AccountCreationDate",
                schema: "MYE",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "MYE",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "MYE",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                schema: "MYE",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UserAddress",
                schema: "MYE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                schema: "MYE",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserAddress_AddressId",
                schema: "MYE",
                table: "AspNetUsers",
                column: "AddressId",
                principalSchema: "MYE",
                principalTable: "UserAddress",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAddress_AddressId",
                schema: "MYE",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserAddress",
                schema: "MYE");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                schema: "MYE",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountCreationDate",
                schema: "MYE",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "MYE",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "MYE",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                schema: "MYE",
                table: "AspNetUsers");
        }
    }
}
