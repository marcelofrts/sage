using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAGE_APP.Models
{
    [Table("MateriasProjetos")]
    public class MateriaProjeto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int MateriaProjetoId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProjetoId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int MateriaId { get; set; }
    }
}