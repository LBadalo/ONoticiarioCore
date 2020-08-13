﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ONoticiarioCore.Data;

namespace ONoticiarioCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200813181056_DB")]
    partial class DB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ONoticiarioCore.Models.Categoria_Noticias", b =>
                {
                    b.Property<int>("categoriaIdFK")
                        .HasColumnType("int");

                    b.Property<int>("noticiaIdFK")
                        .HasColumnType("int");

                    b.HasKey("categoriaIdFK", "noticiaIdFK");

                    b.HasIndex("noticiaIdFK");

                    b.ToTable("Categoria_Noticias");
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Categorias", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TipoCategoria = "as"
                        },
                        new
                        {
                            ID = 2,
                            TipoCategoria = "asd"
                        },
                        new
                        {
                            ID = 3,
                            TipoCategoria = "aasds"
                        },
                        new
                        {
                            ID = 4,
                            TipoCategoria = "asasdadd"
                        },
                        new
                        {
                            ID = 5,
                            TipoCategoria = "as"
                        },
                        new
                        {
                            ID = 6,
                            TipoCategoria = "afd"
                        },
                        new
                        {
                            ID = 7,
                            TipoCategoria = "assds"
                        },
                        new
                        {
                            ID = 8,
                            TipoCategoria = "asassadd"
                        });
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Comentarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoticiasFK")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NoticiasFK");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Comentarios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Data = new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Comentário de teste",
                            NoticiasFK = 1,
                            UtilizadorFK = 3
                        },
                        new
                        {
                            ID = 2,
                            Data = new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Comentário de teste",
                            NoticiasFK = 2,
                            UtilizadorFK = 2
                        });
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Noticias", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Noticias");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Capa = "asd.jpg",
                            Conteudo = "asdasdsada.",
                            Data = new DateTime(2019, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "asdasd.",
                            Titulo = "aaa",
                            UtilizadorFK = 1
                        },
                        new
                        {
                            ID = 2,
                            Capa = "asdasdas.jpg",
                            Conteudo = "asdasdsadasdas",
                            Data = new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "aaaa",
                            Titulo = "asdasdsa",
                            UtilizadorFK = 1
                        },
                        new
                        {
                            ID = 3,
                            Capa = "asdasdas.jpg",
                            Conteudo = "asdasdsadasdas",
                            Data = new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "aaaa",
                            Titulo = "asdasdsa",
                            UtilizadorFK = 1
                        },
                        new
                        {
                            ID = 4,
                            Capa = "asdasdas.jpg",
                            Conteudo = "asdasdsadasdas",
                            Data = new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "aaaa",
                            Titulo = "asdasdsa",
                            UtilizadorFK = 2
                        });
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Utilizadores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Utilizadores");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Avatar = "aa.jpg",
                            DataNascimento = new DateTime(1997, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "a",
                            Email = "admin@ipt.pt",
                            Username = "Luis"
                        },
                        new
                        {
                            ID = 2,
                            Avatar = "aa.jpg",
                            DataNascimento = new DateTime(1970, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "aa",
                            Email = "Jornalista@ipt.com",
                            Username = "AntonioSilva"
                        },
                        new
                        {
                            ID = 3,
                            Avatar = "aa.jpg",
                            DataNascimento = new DateTime(1922, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "aaa",
                            Email = "teste@ipt.pt",
                            Username = "Mauricio"
                        });
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Categoria_Noticias", b =>
                {
                    b.HasOne("ONoticiarioCore.Models.Categorias", "Categorias")
                        .WithMany("ListCatNot")
                        .HasForeignKey("categoriaIdFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ONoticiarioCore.Models.Noticias", "Noticias")
                        .WithMany("ListCatNot")
                        .HasForeignKey("noticiaIdFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Comentarios", b =>
                {
                    b.HasOne("ONoticiarioCore.Models.Noticias", "Noticia")
                        .WithMany("ListaComentarios")
                        .HasForeignKey("NoticiasFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ONoticiarioCore.Models.Utilizadores", "Utilizador")
                        .WithMany("ListaComentarios")
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ONoticiarioCore.Models.Noticias", b =>
                {
                    b.HasOne("ONoticiarioCore.Models.Utilizadores", "Utilizador")
                        .WithMany("ListaNoticias")
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
