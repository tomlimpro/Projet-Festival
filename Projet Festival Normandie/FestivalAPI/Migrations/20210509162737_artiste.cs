using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalAPI.Migrations
{
    public partial class artiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FestivalID",
                table: "Artiste",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artiste_FestivalID",
                table: "Artiste",
                column: "FestivalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artiste_Festival_FestivalID",
                table: "Artiste",
                column: "FestivalID",
                principalTable: "Festival",
                principalColumn: "FestivalID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiste_Festival_FestivalID",
                table: "Artiste");

            migrationBuilder.DropIndex(
                name: "IX_Artiste_FestivalID",
                table: "Artiste");

            migrationBuilder.DropColumn(
                name: "FestivalID",
                table: "Artiste");
        }
    }
}
