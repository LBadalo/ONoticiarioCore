using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ONoticiarioCore.Models
{
    public class Noticias
    {
        public Noticias()
            {
                ListaComentarios = new HashSet<Comentarios>();

                ListaCategorias = new HashSet<Categorias>();
            }

            //Chave primaria
            [Key]
            public int ID { get; set; }

            //Data da publicação
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public DateTime Data { get; set; }

            //Titulo da noticia
            [RegularExpression("^[a-zA-Z0-9_.,áãàâÃÀÁÂÔÒÓÕòóôõÉÈÊéèêíìîÌÍÎúùûçÇ!-.? ]*", ErrorMessage = "O {0} tem caracteres inválidos!")]
            //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
            public string Titulo { get; set; }

            //Capa da Noticia

            public string Capa { get; set; }

            //Chave forasteira
            [ForeignKey("Utilizador")]
            public int UtilizadorFK { get; set; }
            public virtual Utilizadores Utilizador { get; set; }

            //Paragrafo a negrito da Noticia
            [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
            public string Descricao { get; set; }

            //Conteudo da Noticia
            [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
            public string Conteudo { get; set; }



            //Relacionar a noticia aos varios comentarios
            public virtual ICollection<Comentarios> ListaComentarios { get; set; }

            //Relacionar a noticia às varias categorias
            public virtual ICollection<Categorias> ListaCategorias { get; set; }
    }
}
