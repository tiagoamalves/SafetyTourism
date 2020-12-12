using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class Sintoma
    {
        public int SintomaID { get; set; }
        public DateTime DataRegisto { get; set; }
        public string NomeSintoma { get; set; }


        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }

    }
}
