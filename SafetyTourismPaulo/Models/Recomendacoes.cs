using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class Recomendacoe
    {
        public int RecomendacoesID { get; set; }
        public string DataRegisto { get; set; }
        public string Relatorio { get; set; }


        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }
    }
}
