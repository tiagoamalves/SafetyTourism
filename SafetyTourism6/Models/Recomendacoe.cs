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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime DataRegisto { get; set; }
        public string Relatorio { get; set; }


        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }
    }
}
