using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class adicaodonomedoprato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pratos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pratos");
        }
    }
}
