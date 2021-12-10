using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaBackend.Migrations
{
    public partial class InitialCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolesUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(20)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_RolesUsuario_Role",
                        column: x => x.Role,
                        principalTable: "RolesUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Role",
                table: "usuarios",
                column: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "RolesUsuario");
        }
    }
}
