using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONoticiarioCore.Models
{
    public class Categoria_Noticias
    {
        public Categoria_Noticias()
            {
                ListaNoticias = new HashSet<Noticias>();

                ListaCategorias = new HashSet<Categorias>();
            }

        public int catId { get; set; }
        public virtual Categorias Categorias { get; set; }

        public int notId { get; set; }
        public virtual Noticias Noticias { get; set; }


            //Relacionar a noticia aos varios comentarios
            public virtual ICollection<Noticias> ListaNoticias { get; set; }

            //Relacionar a noticia às varias categorias
            public virtual ICollection<Categorias> ListaCategorias { get; set; }
    }
}
