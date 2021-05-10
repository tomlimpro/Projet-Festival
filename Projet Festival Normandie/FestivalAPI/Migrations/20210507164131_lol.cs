using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalAPI.Migrations
{
    public partial class lol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantiteTotal",
                table: "Tarif",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantiteTotal",
                table: "Tarif");
        }
    }
}
