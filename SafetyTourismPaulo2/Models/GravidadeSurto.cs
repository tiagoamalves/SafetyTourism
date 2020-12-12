using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class GravidadeSurto
    {
        public int GravidadeSurtoID { get; set; }
        public DateTime DataRegisto { get; set; }
        public string NivelGravidade { get; set; }



        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }
       
    }
}
