using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class Sintoma
    {
        public int SintomaID { get; set; }

        [Display(Name = "Data de Registo")]
        public DateTime DataRegisto { get; set; }

        [Required]
        [Display(Name = "Nome de Sintoma")]
        public string NomeSintoma { get; set; }


        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }

    }
}
