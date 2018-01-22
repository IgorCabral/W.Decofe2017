using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decofe2017.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public List<Trabalho> Trabalhos { get; set; }
    }
}