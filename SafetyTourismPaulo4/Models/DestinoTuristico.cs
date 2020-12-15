using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class DestinoTuristico
    {
        public int DestinoTuristicoID { get; set; }

        [Required]
        [Display(Name = "Destino")]
        public string NomeDestino { get; set; }

        [Display(Name = "Densidade Demografica")]

        public string DensidadeDemografica { get; set; }

        [Required]
        [Display(Name = "País")]

        public string Pais { get; set; }

        [Required]
        public string Continente { get; set; }

        

        public ICollection<SurtosOcurrencia> SurtosOcurrencias { get; set; }


    }
}
