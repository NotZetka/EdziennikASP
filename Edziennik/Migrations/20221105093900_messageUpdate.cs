using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edziennik.Migrations
{
    public partial class messageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opened",
                table: "Marks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "Opened",
                table: "Messages",
                type: "bit",
                maxLength: 100,
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opened",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Messages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Opened",
                table: "Marks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
