using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class Recomendacoe
    {
        public int RecomendacoeID { get; set; }

        [Display(Name = "Data de Registo")]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Relatório")]
        public string Relatorio { get; set; }


        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }
    }
}
