using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalAPI.Migrations
{
    public partial class es : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionTarif",
                table: "Tarif",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionTarif",
                table: "Tarif");
        }
    }
}
