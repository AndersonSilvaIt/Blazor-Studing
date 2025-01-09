using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalCursos.Api.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CursoNome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Logo = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Foto = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Genero = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CargaHoraria", "CursoNome", "Descricao", "Inicio", "Logo", "Preco" },
                values: new object[] { 1, 40, "CSharp Básico", "Curso de C# Básico", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150.00m });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CargaHoraria", "CursoNome", "Descricao", "Inicio", "Logo", "Preco" },
                values: new object[] { 2, 40, "ASP .NET Core Básico", "Curso de ASP .NET Core Básico", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 250.00m });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "CursoId", "Email", "Foto", "Genero", "Nascimento", "Nome", "Sobrenome" },
                values: new object[] { 1, 1, "felipe@email.com", null, 0, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felipe", "Ribeiro" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "CursoId", "Email", "Foto", "Genero", "Nascimento", "Nome", "Sobrenome" },
                values: new object[] { 2, 2, "maria@email.com", null, 1, new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "Silveira" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
