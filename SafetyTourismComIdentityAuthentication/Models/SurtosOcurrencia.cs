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

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Relatório")]
        public string Relatorio { get; set; }

        [Display(Name = "Surto Epidemiológico")]
        public int SurtosEpidemiologicoID { get; set; }

        public int DestinoTuristicoID { get; set; }

        [Display(Name = "Surto Epidemiológico")]
        public SurtosEpidemiologico SurtosEpidemiologico { get; set; }

        [Display(Name = "Local")]
        public DestinoTuristico DestinoTuristico { get; set; }
    }
}
