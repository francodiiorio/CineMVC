using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineXperience.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Legajo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcion_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcion_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    CantAsientos = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entradas_Funcion_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entradas_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ClienteId",
                table: "Entradas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_FuncionId",
                table: "Entradas",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_PeliculaId",
                table: "Funcion",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_SalaId",
                table: "Funcion",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Funcion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
