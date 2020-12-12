using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class Doenca
    {
        public int DoencaID { get; set; }
        public string NomeDoenca { get; set; }

       

        public ICollection<GrupoRisco> GrupoRiscos { get; set; }

    }
}
