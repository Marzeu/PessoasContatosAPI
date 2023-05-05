using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PessoasContatosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Refatoracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Contatos",
                newName: "Contato");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Contato",
                newName: "Valor");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contato",
                newName: "IX_Contato_PessoaId");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Pessoa_PessoaId",
                table: "Contato",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Pessoa_PessoaId",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "Contatos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Contatos",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_Contato_PessoaId",
                table: "Contatos",
                newName: "IX_Contatos_PessoaId");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Contatos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }
    }
}
