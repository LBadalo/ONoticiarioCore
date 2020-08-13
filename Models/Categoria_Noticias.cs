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
        [ForeignKey("Categorias")]
        public int categoriaIdFK { get; set; }
        public virtual Categorias Categorias { get; set; }

        [ForeignKey("Noticias")]
        public int noticiaIdFK { get; set; }
        public virtual Noticias Noticias { get; set; }

    }
}
