using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class SurtosOcurrencia
    {
        public int SurtosOcurrenciaID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime DataInicio { get; set; }
        
        public int SurtosEpidemiologicoID { get; set; }

        public int DestinoTuristicoID { get; set; }
        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }
        public DestinoTuristico DestinoTuristico { get; set; }
    }
}
