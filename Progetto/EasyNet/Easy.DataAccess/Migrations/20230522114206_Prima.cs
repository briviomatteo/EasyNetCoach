using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Prima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentos",
                columns: table => new
                {
                    IdCommento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Testo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkPost = table.Column<int>(type: "int", nullable: false),
                    FkUtente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentos", x => x.IdCommento);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    IdPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkUtente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.IdPost);
                });

            migrationBuilder.CreateTable(
                name: "Utentes",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FotoProfilo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkPost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utentes", x => x.IdUtente);
                    table.ForeignKey(
                        name: "FK_Utentes_Posts_FkPost",
                        column: x => x.FkPost,
                        principalTable: "Posts",
                        principalColumn: "IdPost",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentos_FkPost",
                table: "Commentos",
                column: "FkPost");

            migrationBuilder.CreateIndex(
                name: "IX_Commentos_FkUtente",
                table: "Commentos",
                column: "FkUtente");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FkUtente",
                table: "Posts",
                column: "FkUtente");

            migrationBuilder.CreateIndex(
                name: "IX_Utentes_FkPost",
                table: "Utentes",
                column: "FkPost");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentos_Posts_FkPost",
                table: "Commentos",
                column: "FkPost",
                principalTable: "Posts",
                principalColumn: "IdPost",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentos_Utentes_FkUtente",
                table: "Commentos",
                column: "FkUtente",
                principalTable: "Utentes",
                principalColumn: "IdUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Utentes_FkUtente",
                table: "Posts",
                column: "FkUtente",
                principalTable: "Utentes",
                principalColumn: "IdUtente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utentes_Posts_FkPost",
                table: "Utentes");

            migrationBuilder.DropTable(
                name: "Commentos");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Utentes");
        }
    }
}
