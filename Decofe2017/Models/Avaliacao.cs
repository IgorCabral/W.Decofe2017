using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Decofe2017.Models
{
    public class Avaliacao
    {   
        [Key]
        public int AvaliacaoId { get; set; }
        [Required]
        public int? Conjunto { get; set; }
        [Required]
        public int? PainelAutoexplicativo { get; set; }
        [Required]
        public int? Proposicao { get; set; }
        [Required]
        public int? Coerencia { get; set; }
        [Required]
        public int? Contribuicao { get; set; }

        public int AvaliadorId { get; set; }

        public virtual Avaliador Avaliador { get; set; }

        
        public int TrabalhoId { get; set; }

        public virtual Trabalho Trabalho { get; set; }
    }
}