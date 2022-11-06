using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edziennik.Migrations
{
    public partial class markUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Opened",
                table: "Marks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opened",
                table: "Marks");
        }
    }
}
