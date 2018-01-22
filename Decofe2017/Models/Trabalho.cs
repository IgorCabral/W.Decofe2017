using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Decofe2017.Models
{
    public class Trabalho
    {           
        public int TrabalhoId { get; set; }

        public int AvaliadorId { get; set; }
        public virtual Avaliador Avaliador { get; set; }    

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string CodigoTrabalho { get; set; }
        public string Titulo { get; set; }
        public DateTime DataApresentacao { get; set; }
        public bool Ausente { get; set; }
        public DateTime DataEnvio { get; set; }        
    }
}