using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ONoticiarioCore.Models
{
    public class Utilizadores
    {

        //construtor
        public Utilizadores()
        {
            ListaComentarios = new HashSet<Comentarios>();
            ListaNoticias = new HashSet<Noticias>();
        }

        //ID
        [Key]
        public int ID { get; set; }

        //Nome do utilizador
        //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        //[StringLength(40, ErrorMessage = "O {0} não pode ter mais de {1} carateres.")]
        //[RegularExpression("^[a-zA-Z0-9_.,áãàâÃÀÁÂÔÒÓÕòóôõÉÈÊéèêíìîÌÍÎúùûçÇ!-.? ]*", ErrorMessage = "O {0} tem caracteres inválidos!")]
        public string Username { get; set; }

        //Data nascimento
        //data no formato ano/mes/dia
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        //Descricao do utilizador
        public string Descricao { get; set; }

        public string Avatar { get; set; }

        //atributo auxiliar para relacionar a tabela dos utilizadores Asp.Net com a tabela utilizadores
        //[RegularExpression("^[a-zA-Z0-9_.,áãàâÃÀÁÂÔÒÓÕòóôõÉÈÊéèêíìîÌÍÎúùûçÇ!-.? ]*", ErrorMessage = "O {0} tem caracteres inválidos!")]
        //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Email { get; set; }

        //Relacionar o utilizadoes às varias noticias onde escreveu e quais comentarios
        public virtual ICollection<Comentarios> ListaComentarios { get; set; }
        public virtual ICollection<Noticias> ListaNoticias { get; set; }

    }
}
