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
        [RegularExpression(@"^[A-Z][a-z]+(\W[A-Z][a-z]+)*")]
        public string NomeDestino { get; set; }

        [Display(Name = "Densidade Demografica")]
        [RegularExpression(@"[0-9]+")]
        public string DensidadeDemografica { get; set; }

        [Required]
        [Display(Name = "País")]
        [RegularExpression(@"^[A-Z][a-z]+(\W[A-Z][a-z]+)*")]
        public string Pais { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+(\W[A-Z][a-z]+)*")]
        public string Continente { get; set; }

        
        public ICollection<SurtosOcurrencia> SurtosOcurrencias { get; set; }


    }
}
