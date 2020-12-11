using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class SurtosOcurrencia
    {
        public int SurtosOcurrenciaID { get; set; }
        public string DataInicio { get; set; }
        public string Relatorio { get; set; }


        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }
        public DestinoTuristico DestinoTuristico { get; set; }
    }
}
