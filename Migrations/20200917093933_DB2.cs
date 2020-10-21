using Microsoft.EntityFrameworkCore.Migrations;

namespace ONoticiarioCore.Migrations
{
    public partial class DB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria_Noticias",
                columns: new[] { "CategoriaIdFK", "NoticiaIdFK" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Categoria_Noticias",
                columns: new[] { "CategoriaIdFK", "NoticiaIdFK" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Categoria_Noticias",
                columns: new[] { "CategoriaIdFK", "NoticiaIdFK" },
                values: new object[] { 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria_Noticias",
                keyColumns: new[] { "CategoriaIdFK", "NoticiaIdFK" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Categoria_Noticias",
                keyColumns: new[] { "CategoriaIdFK", "NoticiaIdFK" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Categoria_Noticias",
                keyColumns: new[] { "CategoriaIdFK", "NoticiaIdFK" },
                keyValues: new object[] { 3, 1 });
        }
    }
}
