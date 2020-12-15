using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class SurtosEpidemiologico
    {
        public int SurtosEpidemiologicoID { get; set; }

        [Required]
        [Display(Name = "Doença")]
        public string NomeSurto { get; set; }

        [Required]
        [Display(Name = "Grau de Contágio")]
        public string GrauContagio { get; set; }

        [Required]
        [Display(Name = "Índice de Mortalidade")]
        public string IndiceMortalidade { get; set; }

        [Display(Name = "Gravidade do Surto")]
        public int GravidadeSurtoID { get; set; }

        [Display(Name = "Recomendações")]
        public int RecomendacoeID { get; set; }

        [Display(Name = "Sintomas")]
        public int SintomaID { get; set; }

        [Display(Name = "Grupos de Risco")]
        public int GrupoRiscoID { get; set; }
        

        public Sintoma Sintoma { get; set; }
        public GrupoRisco GrupoRisco { get; set; }
        public Recomendacoe Recomendacoe { get; set; }

        public GravidadeSurto GravidadeSurto { get; set; }

        public ICollection<SurtosOcurrencia> SurtosOcurrencias { get; set; }
    }
}
