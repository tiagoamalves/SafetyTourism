using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourism.Models
{
    public class Recomendacoe
    {
        public int RecomendacoeID { get; set; }
        public DateTime DataRegisto { get; set; }
        public string Relatorio { get; set; }


        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }
    }
}
