using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAGE_APP.Models
{
    [Table("Materias")]
    public class Materia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MateriaId { get; set; }
        public int UserId { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
    }
}