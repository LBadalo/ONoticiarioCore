using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONoticiarioCore.Models
{
    public class Categorias
    {
        public Categorias()
        {
            ListCatNot = new HashSet<Categoria_Noticias>();
        }

        [Key]
        public int ID { get; set; }

        //Nome da categoria
        [RegularExpression("[A-ZÍÉÂÁ]*[a-záéíóúàèìòùâêîôûäëïöüãõç -]*", ErrorMessage = "A {0} só pode conter letras.")]
        //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string TipoCategoria { get; set; }
        
        //Relacionar as categorias com as noticias
             public virtual ICollection<Categoria_Noticias> ListCatNot { get; set; }
    }
}
