using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class SurtosOcurrencia
    {
        public int SurtosOcurrenciaID { get; set; }
        public DateTime DataInicio { get; set; }
        public string Relatorio { get; set; }

        public int SurtosEpidemiologicoID { get; set; }

        public int DestinoTuristicoID { get; set; }
        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }
        public DestinoTuristico DestinoTuristico { get; set; }
    }
}
