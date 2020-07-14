using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ONoticiarioCore.Models;


namespace ONoticiarioCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);



            //Inicio do SEED




            //Categorias

            modelBuilder.Entity<Categorias>().HasData(

                        new Categorias { ID = 1, TipoCategoria = "as" },
                        new Categorias { ID = 2, TipoCategoria = "asd" },
                        new Categorias { ID = 3, TipoCategoria = "aasds" },
                        new Categorias { ID = 4, TipoCategoria = "asasdadd" },
                        new Categorias { ID = 5, TipoCategoria = "as" },
                        new Categorias { ID = 6, TipoCategoria = "asd" },
                        new Categorias { ID = 7, TipoCategoria = "aasds" },
                        new Categorias { ID = 8, TipoCategoria = "asasdadd" }
                    );
            //categorias.ForEach(aa => context.Categorias.AddOrUpdate(a => a.TipoCategoria, aa));
            //context.SaveChanges();

            //Utilizadores
            modelBuilder.Entity<Utilizadores>().HasData(
                        new Utilizadores { Avatar = "aa.jpg", ID = 1, Descricao = "a", Username = "Luis", Email = "admin@ipt.pt", DataNascimento = new DateTime(1997, 9, 29) },
                        new Utilizadores { Avatar = "aa.jpg", ID = 2, Descricao = "aa", Username = "AntonioSilva", Email = "Jornalista@ipt.com", DataNascimento = new DateTime(1970, 2, 09) },
                        new Utilizadores { Avatar = "aa.jpg", ID = 3, Descricao = "aaa", Username = "Mauricio", Email = "teste@ipt.pt", DataNascimento = new DateTime(1922, 2, 20) }
                    );
            //utilizadores.ForEach(aa => context.Utilizadores.AddOrUpdate(a => a.Username, aa));
            //context.SaveChanges();

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
                                Capa = "asd.jpg",
                                UtilizadorFK = 1,
                                Descricao = "asdasd.",
                                Conteudo = "asdasdsada.",
                                ///
                                ListaCategorias = new List<Categorias> { },
                                ListaComentarios = new List<Comentarios> { }
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
                              ///
                              ListaCategorias = new List<Categorias> { },
                              ListaComentarios = new List<Comentarios> { }
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
                               ///
                               ListaCategorias = new List<Categorias> { },
                               ListaComentarios = new List<Comentarios> { }
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
                                ///
                                ListaCategorias = new List<Categorias> { new Categorias {ID = 1}, new Categorias { ID = 2 } },
                                ListaComentarios = new List<Comentarios> { }
                            }
                    );
            modelBuilder.Entity<Categoria_Noticias>()
                .HasKey(nc => new { nc.catId, nc.notId });
            modelBuilder.Entity<Categoria_Noticias>()
                .HasOne(nc => nc.Noticias)
                .WithMany(c => c.ListaCategorias)
                .HasForeignKey(nc => nc.notId);
            modelBuilder.Entity<Categoria_Noticias>()
                .HasOne(nc => nc.Categorias)
                .WithMany(c => c.ListaNoticias)
                .HasForeignKey(nc => nc.catId);

            //noticias.ForEach(aa => context.Noticias.AddOrUpdate(a => a.Data, aa));
            //context.SaveChanges();


        }

        //comentarios.ForEach(aa => context.Comentarios.AddOrUpdate(a => a.Descricao, aa));
        //context.SaveChanges();

        // adicionar as 'tabelas' à BD

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Categoria_Noticias> Categoria_Noticias { get; set; }

    }

}

