using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Classificacao
    {
        public int ClassificacaoId { get; set; }
        public decimal Nota { get; set; }
        public int FormandoId { get; set; }
        public int UFormId { get; set; }

        public Formando Formando { get; set; }
        public UForm UForm { get; set; }

    }
}
