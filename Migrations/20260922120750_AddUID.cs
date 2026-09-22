using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_Shop.Migrations
{
    public partial class AddUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "Categories");
        }
    }
}