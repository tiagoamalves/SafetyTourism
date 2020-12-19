using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class GrupoRisco
    {
        public int GrupoRiscoID { get; set; }

        [Required]
        [Display(Name = "Faixa Etária")]
        public string FaixaEtaria { get; set; }

        public string Sexo { get; set; }

        public string Etnia { get; set; }

        [Required]
        [Display(Name = "Doença")]
        public int DoencaID { get; set; }

     
        public Doenca Doenca { get; set; }
        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }

    }
}
