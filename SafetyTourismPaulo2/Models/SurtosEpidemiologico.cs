using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class SurtosEpidemiologico
    {
        public int SurtosEpidemiologicoID { get; set; }
        public string NomeSurto { get; set; }
        public string GrauContagio { get; set; }
        public string IndiceMortalidade { get; set; }
        public int GravidadeSurtoID { get; set; }
        public int RecomendacoeID { get; set; }
        public int SintomaID { get; set; }

        public int GrupoRiscoID { get; set; }
        

        public Sintoma Sintoma { get; set; }
        public GrupoRisco GrupoRisco { get; set; }
        public Recomendacoe Recomendacoe { get; set; }

        public GravidadeSurto GravidadeSurto { get; set; }

        public ICollection<SurtosOcurrencia> SurtosOcurrencias { get; set; }
    }
}
