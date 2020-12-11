using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class SurtosEpidemiologico
    {
        public int SurtosEpidemiológicoID { get; set; }
        public string NomeSurto { get; set; }
        public string GrauContagio { get; set; }
        public string IndiceMortalidade { get; set; }

        

        public ICollection<Sintoma> Sintomas { get; set; }
        public ICollection<Recomendacoe> Recomendacoes { get; set; }

        public ICollection<GravidadeSurto> GravidadeSurtos { get; set; }
    }
}
