using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class GravidadeSurto
    {
        public int GravidadeSurtoID { get; set; }
        public string DataRegisto { get; set; }
        public string DesignacaoSintoma { get; set; }


        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }
       
    }
}
