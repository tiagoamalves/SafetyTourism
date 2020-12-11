using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismPaulo.Models
{
    public class DestinoTuristico
    {
        public int DestinoTuristicoID { get; set; }
        public string NomeDestino { get; set; }
        public string DensidadeDemografica { get; set; }
        public string Pais { get; set; }

        public string Continente { get; set; }

        public ICollection<SurtosOcurrencia> SurtosOcurrencias { get; set; }

    }
}
