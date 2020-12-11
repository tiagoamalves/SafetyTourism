using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class GrupoRisco
    {
        public int GrupoRiscoID { get; set; }
        public string FaixaEtaria { get; set; }
        public string Sexo { get; set; }
        public string Etnia { get; set; }

        public ICollection<Doenca> Doencas { get; set; }
        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }

    }
}
