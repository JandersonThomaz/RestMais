using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class mudancadevalorparapreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Pratos",
                newName: "Preco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Pratos",
                newName: "Valor");
        }
    }
}
