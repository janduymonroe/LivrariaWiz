using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaBackend.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    SobreNome = table.Column<string>(type: "varchar(60)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(60)", nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    AnoLancamento = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_livros_autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_livros_AutorId",
                table: "livros",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "livros");

            migrationBuilder.DropTable(
                name: "autores");
        }
    }
}
