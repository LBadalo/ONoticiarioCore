using Microsoft.EntityFrameworkCore.Migrations;

namespace ONoticiarioCore.Migrations
{
    public partial class DB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Noticias",
                keyColumn: "ID",
                keyValue: 1,
                column: "Capa",
                value: "asd.png");

            migrationBuilder.UpdateData(
                table: "Noticias",
                keyColumn: "ID",
                keyValue: 2,
                column: "Capa",
                value: "asdasdas.png");

            migrationBuilder.UpdateData(
                table: "Noticias",
                keyColumn: "ID",
                keyValue: 3,
                column: "Capa",
                value: "asdasdas.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Noticias",
                keyColumn: "ID",
                keyValue: 1,
                column: "Capa",
                value: "asd.jpg");

            migrationBuilder.UpdateData(
                table: "Noticias",
                keyColumn: "ID",
                keyValue: 2,
                column: "Capa",
                value: "asdasdas.jpg");

            migrationBuilder.UpdateData(
                table: "Noticias",
                keyColumn: "ID",
                keyValue: 3,
                column: "Capa",
                value: "asdasdas.jpg");
        }
    }
}
