using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class GravidadeSurto
    {
        public int GravidadeSurtoID { get; set; }

        [Display(Name = "Data de Registo")]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Nível de Gravidade")]
        public string NivelGravidade { get; set; }



        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }
       
    }
}
