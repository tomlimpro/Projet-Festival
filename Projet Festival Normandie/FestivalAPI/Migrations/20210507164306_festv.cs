using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalAPI.Migrations
{
    public partial class festv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantitePlace",
                table: "Festival",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantitePlace",
                table: "Festival");
        }
    }
}
