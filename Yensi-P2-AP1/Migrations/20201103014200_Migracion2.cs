using Microsoft.EntityFrameworkCore.Migrations;

namespace Yensi_P2_AP1.Migrations
{
    public partial class Migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoID", "tipo" },
                values: new object[] { 2, "APrender Css" });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoID", "tipo" },
                values: new object[] { 3, "APrender JS" });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "TipoID", "tipo" },
                values: new object[] { 4, "APrender C#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "TipoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "TipoID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "TipoID",
                keyValue: 4);
        }
    }
}
