using Microsoft.EntityFrameworkCore.Migrations;

namespace Yensi_P2_AP1.Migrations
{
    public partial class M3gracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tiempo",
                table: "Proyectos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tiempo",
                table: "Proyectos");
        }
    }
}
