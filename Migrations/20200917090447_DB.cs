using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ONoticiarioCore.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Capa = table.Column<string>(nullable: true),
                    UtilizadorFK = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Conteudo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Noticias_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria_Noticias",
                columns: table => new
                {
                    categoriaIdFK = table.Column<int>(nullable: false),
                    noticiaIdFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Noticias", x => new { x.categoriaIdFK, x.noticiaIdFK });
                    table.ForeignKey(
                        name: "FK_Categoria_Noticias_Categorias_categoriaIdFK",
                        column: x => x.categoriaIdFK,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categoria_Noticias_Noticias_noticiaIdFK",
                        column: x => x.noticiaIdFK,
                        principalTable: "Noticias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    UtilizadorFK = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    NoticiasFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentarios_Noticias_NoticiasFK",
                        column: x => x.NoticiasFK,
                        principalTable: "Noticias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "TipoCategoria" },
                values: new object[,]
                {
                    { 1, "as" },
                    { 2, "asd" },
                    { 3, "aasds" },
                    { 4, "asasdadd" },
                    { 5, "as" },
                    { 6, "afd" },
                    { 7, "assds" },
                    { 8, "asassadd" }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "ID", "Avatar", "DataNascimento", "Descricao", "Email", "Username" },
                values: new object[,]
                {
                    { 1, "aa.jpg", new DateTime(1997, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "a", "admin@ipt.pt", "Luis" },
                    { 2, "aa.jpg", new DateTime(1970, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "aa", "Jornalista@ipt.com", "AntonioSilva" },
                    { 3, "aa.jpg", new DateTime(1922, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa", "teste@ipt.pt", "Mauricio" }
                });

            migrationBuilder.InsertData(
                table: "Noticias",
                columns: new[] { "ID", "Capa", "Conteudo", "Data", "Descricao", "Titulo", "UtilizadorFK" },
                values: new object[,]
                {
                    { 1, "asd.jpg", "asdasdsada.", new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdasd.", "aaa", 1 },
                    { 2, "asdasdas.jpg", "asdasdsadasdas", new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaa", "asdasdsa", 1 },
                    { 3, "asdasdas.jpg", "asdasdsadasdas", new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaa", "asdasdsa", 1 },
                    { 4, "asdasdas.jpg", "asdasdsadasdas", new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaa", "asdasdsa", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "ID", "Data", "Descricao", "NoticiasFK", "UtilizadorFK" },
                values: new object[] { 1, new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comentário de teste", 1, 3 });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "ID", "Data", "Descricao", "NoticiasFK", "UtilizadorFK" },
                values: new object[] { 2, new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comentário de teste", 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Noticias_noticiaIdFK",
                table: "Categoria_Noticias",
                column: "NoticiaIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_NoticiasFK",
                table: "Comentarios",
                column: "NoticiasFK");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UtilizadorFK",
                table: "Comentarios",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_UtilizadorFK",
                table: "Noticias",
                column: "UtilizadorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria_Noticias");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
