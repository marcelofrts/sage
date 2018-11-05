using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAGE_APP.Models
{
    [Table("Projetos")]
    public class Projeto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProjetoId { get; set; }
        public int UserId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataProva { get; set; }
        public int NumVagas { get; set; }
    }
}