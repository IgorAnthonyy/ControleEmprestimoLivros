using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosLivros.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoCampoEmailCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "IdLivro",
                table: "Emprestimo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLivro",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
