using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorPelicula2020.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Resumen = table.Column<string>(nullable: true),
                    EnCartelera = table.Column<bool>(nullable: false),
                    Trailer = table.Column<string>(nullable: true),
                    Lanzamiento = table.Column<DateTime>(nullable: false),
                    Poster = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Biografia = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    FechaNacimeinto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneroPeliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPeliculas", x => new { x.GeneroId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_GeneroPeliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroPeliculas_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "peliculaActores",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false),
                    PeliculaId = table.Column<int>(nullable: false),
                    Personaje = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peliculaActores", x => new { x.PeliculaId, x.PersonaId });
                    table.ForeignKey(
                        name: "FK_peliculaActores_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_peliculaActores_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPeliculas_PeliculaId",
                table: "GeneroPeliculas",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_peliculaActores_PersonaId",
                table: "peliculaActores",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroPeliculas");

            migrationBuilder.DropTable(
                name: "peliculaActores");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
