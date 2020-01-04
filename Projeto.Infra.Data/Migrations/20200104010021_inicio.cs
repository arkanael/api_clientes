using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(175)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(75)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(65)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(25)", nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdCliente",
                table: "Endereco",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
