using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_Shop.Migrations
{
    public partial class TestUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "UserFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "EmployeeFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "UID", table: "Users");
            migrationBuilder.DropColumn(name: "UID", table: "Roles");
            migrationBuilder.DropColumn(name: "UID", table: "Permissions");
            migrationBuilder.DropColumn(name: "UID", table: "Customers");
            migrationBuilder.DropColumn(name: "UID", table: "Orders");
            migrationBuilder.DropColumn(name: "UID", table: "OrderItems");
            migrationBuilder.DropColumn(name: "UID", table: "UserFiles");
            migrationBuilder.DropColumn(name: "UID", table: "EmployeeFiles");
            migrationBuilder.DropColumn(name: "UID", table: "Employees");
            migrationBuilder.DropColumn(name: "UID", table: "Products");
        }
    }
}