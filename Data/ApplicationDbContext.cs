using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ONoticiarioCore.Models;


namespace ONoticiarioCore.Data
{


    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// nome da pessoa q se regista, e posteriormente, autentica
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// avatar da pessoa q se regista, e posteriormente, autentica
        /// </summary>
        public string Fotografia { get; set; }

        /// <summary>
        /// registo da hora+data da criação do registo
        /// </summary>
        public DateTime Timestamp { get; set; }
    }


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
            //Inicio do SEED

            //Noticias com comentários
            modelBuilder.Entity<Categoria_Noticias>()
                .HasKey(nc => new { nc.CategoriaIdFK, nc.NoticiaIdFK });
            modelBuilder.Entity<Categoria_Noticias>()
                .HasOne(nc => nc.Noticias)
                .WithMany(c => c.ListCatNot)
                .HasForeignKey(nc => nc.NoticiaIdFK);
            modelBuilder.Entity<Categoria_Noticias>()
                .HasOne(nc => nc.Categorias)
                .WithMany(c => c.ListCatNot)
                .HasForeignKey(nc => nc.CategoriaIdFK);



            //Categorias

            modelBuilder.Entity<Categorias>().HasData(

                        new Categorias { ID = 1, TipoCategoria = "as" },
                        new Categorias { ID = 2, TipoCategoria = "asd" },
                        new Categorias { ID = 3, TipoCategoria = "aasds" },
                        new Categorias { ID = 4, TipoCategoria = "asasdadd" },
                        new Categorias { ID = 5, TipoCategoria = "as" },
                        new Categorias { ID = 6, TipoCategoria = "afd" },
                        new Categorias { ID = 7, TipoCategoria = "assds" },
                        new Categorias { ID = 8, TipoCategoria = "asassadd" }
                    );

           

            //Utilizadores
            modelBuilder.Entity<Utilizadores>().HasData(
                        new Utilizadores { Avatar = "aa.jpg", ID = 1, Descricao = "a", Username = "Luis", Email = "admin@ipt.pt", DataNascimento = new DateTime(1997, 9, 29) },
                        new Utilizadores { Avatar = "aa.jpg", ID = 2, Descricao = "aa", Username = "AntonioSilva", Email = "Jornalista@ipt.com", DataNascimento = new DateTime(1970, 2, 09) },
                        new Utilizadores { Avatar = "aa.jpg", ID = 3, Descricao = "aaa", Username = "Mauricio", Email = "teste@ipt.pt", DataNascimento = new DateTime(1922, 2, 20) }
                    );


            //criação de comentários
             modelBuilder.Entity<Comentarios>().HasData(
                new Comentarios { ID = 1, Descricao = "Comentário de teste", UtilizadorFK = 3, Data = new DateTime(2019, 6, 28), NoticiasFK = 1 },
                        new Comentarios { ID = 2, Descricao = "Comentário de teste", Data = new DateTime(2019, 6, 28), UtilizadorFK = 2, NoticiasFK = 2 }
                    );

            //criação das noticias
            modelBuilder.Entity<Noticias>().HasData(

                            new Noticias
                            {
                                ID = 1,
                                Data = new DateTime(2019, 06, 28),
                                Titulo = "aaa",
                                Capa = "coldzera.jpg",
                                UtilizadorFK = 1,
                                Descricao = "asdasd.",
                                Conteudo = "asdasdsada.",
                            },
                          new Noticias
                          {
                              ID = 2,
                              Data = new DateTime(2019, 07, 07),
                              Titulo = "asdasdsa",
                              Capa = "asdasdas.jpg",
                              UtilizadorFK = 1,
                              Descricao = "aaaa",
                              Conteudo = "asdasdsadasdas",
                          },
                           new Noticias
                           {
                               ID = 3,
                               Data = new DateTime(2019, 07, 07),
                               Titulo = "asdasdsa",
                               Capa = "asdasdas.jpg",
                               UtilizadorFK = 1,
                               Descricao = "aaaa",
                               Conteudo = "asdasdsadasdas",
                           },
                            new Noticias
                            {
                                ID = 4,
                                Data = new DateTime(2019, 07, 07),
                                Titulo = "asdasdsa",
                                Capa = "asdasdas.jpg",
                                UtilizadorFK = 2,
                                Descricao = "aaaa",
                                Conteudo = "asdasdsadasdas",
                            }
                    );
            modelBuilder.Entity<Categoria_Noticias>().HasData(
                    
                    new Categoria_Noticias {CategoriaIdFK = 1, NoticiaIdFK = 1 },
                    new Categoria_Noticias { CategoriaIdFK = 2, NoticiaIdFK = 1 },
                    new Categoria_Noticias { CategoriaIdFK = 3, NoticiaIdFK = 1 }

                );

        }


        // adicionar as 'tabelas' à BD
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Categoria_Noticias> Categoria_Noticias { get; set; }

    }

}

