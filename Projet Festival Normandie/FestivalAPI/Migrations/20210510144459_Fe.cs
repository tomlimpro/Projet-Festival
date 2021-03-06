using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalAPI.Migrations
{
    public partial class Fe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festival",
                columns: table => new
                {
                    FestivalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Festival = table.Column<string>(nullable: false),
                    Ville = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    QuantitePlace = table.Column<int>(nullable: false),
                    Publier = table.Column<bool>(nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.FestivalID);
                });

            migrationBuilder.CreateTable(
                name: "Festivalier",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Mot_de_passe = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(maxLength: 10, nullable: true),
                    Code_postal = table.Column<int>(nullable: false),
                    Commune = table.Column<string>(nullable: true),
                    Pays = table.Column<string>(nullable: true),
                    Date_de_naissance = table.Column<DateTime>(nullable: false),
                    EmailConfirme = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivalier", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Gestionnaire",
                columns: table => new
                {
                    IdGestionnaire = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Mdp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestionnaire", x => x.IdGestionnaire);
                });

            migrationBuilder.CreateTable(
                name: "Hebergement",
                columns: table => new
                {
                    HebergementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeHebergement = table.Column<string>(nullable: true),
                    LienHebergement = table.Column<string>(nullable: true),
                    FestivalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hebergement", x => x.HebergementID);
                    table.ForeignKey(
                        name: "FK_Hebergement_Festival_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festival",
                        principalColumn: "FestivalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisateur",
                columns: table => new
                {
                    OrganisateurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Mot_de_passe = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FestivalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisateur", x => x.OrganisateurID);
                    table.ForeignKey(
                        name: "FK_Organisateur_Festival_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festival",
                        principalColumn: "FestivalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scene",
                columns: table => new
                {
                    SceneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Scene = table.Column<string>(nullable: false),
                    Capacite = table.Column<int>(nullable: false),
                    Accessibilite = table.Column<string>(nullable: true),
                    FestivalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scene", x => x.SceneID);
                    table.ForeignKey(
                        name: "FK_Scene_Festival_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festival",
                        principalColumn: "FestivalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarif",
                columns: table => new
                {
                    TarifID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomTarif = table.Column<string>(nullable: false),
                    PrixTarif = table.Column<int>(nullable: false),
                    QuantiteTotal = table.Column<int>(nullable: false),
                    DescriptionTarif = table.Column<string>(nullable: true),
                    FestivalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarif", x => x.TarifID);
                    table.ForeignKey(
                        name: "FK_Tarif_Festival_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festival",
                        principalColumn: "FestivalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FestivalierAssignment",
                columns: table => new
                {
                    FestivalID = table.Column<int>(nullable: false),
                    FestivalierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalierAssignment", x => new { x.FestivalID, x.FestivalierID });
                    table.ForeignKey(
                        name: "FK_FestivalierAssignment_Festival_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festival",
                        principalColumn: "FestivalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalierAssignment_Festivalier_FestivalierID",
                        column: x => x.FestivalierID,
                        principalTable: "Festivalier",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artiste",
                columns: table => new
                {
                    ArtisteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Artiste = table.Column<string>(nullable: false),
                    Style_Artiste = table.Column<string>(nullable: true),
                    Descriptif_Artiste = table.Column<string>(nullable: true),
                    Pays_Artiste = table.Column<string>(nullable: true),
                    ExtraitMusical_Artiste = table.Column<string>(nullable: true),
                    FestivalID = table.Column<int>(nullable: true),
                    SceneID = table.Column<int>(nullable: true),
                    UrlImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiste", x => x.ArtisteID);
                    table.ForeignKey(
                        name: "FK_Artiste_Festival_FestivalID",
                        column: x => x.FestivalID,
                        principalTable: "Festival",
                        principalColumn: "FestivalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artiste_Scene_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scene",
                        principalColumn: "SceneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artiste_FestivalID",
                table: "Artiste",
                column: "FestivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Artiste_SceneID",
                table: "Artiste",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalierAssignment_FestivalierID",
                table: "FestivalierAssignment",
                column: "FestivalierID");

            migrationBuilder.CreateIndex(
                name: "IX_Hebergement_FestivalID",
                table: "Hebergement",
                column: "FestivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisateur_FestivalID",
                table: "Organisateur",
                column: "FestivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Scene_FestivalID",
                table: "Scene",
                column: "FestivalID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarif_FestivalID",
                table: "Tarif",
                column: "FestivalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiste");

            migrationBuilder.DropTable(
                name: "FestivalierAssignment");

            migrationBuilder.DropTable(
                name: "Gestionnaire");

            migrationBuilder.DropTable(
                name: "Hebergement");

            migrationBuilder.DropTable(
                name: "Organisateur");

            migrationBuilder.DropTable(
                name: "Tarif");

            migrationBuilder.DropTable(
                name: "Scene");

            migrationBuilder.DropTable(
                name: "Festivalier");

            migrationBuilder.DropTable(
                name: "Festival");
        }
    }
}
