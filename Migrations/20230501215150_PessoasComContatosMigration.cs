using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PessoasContatosAPI.Migrations
{
    /// <inheritdoc />
    public partial class PessoasComContatosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Contatos");
        }
    }
}
