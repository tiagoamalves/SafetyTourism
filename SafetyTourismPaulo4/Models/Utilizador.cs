using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class Utilizador
    {
        public int UtilizadorID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string NomeUtilizador { get; set; }

        [Display(Name = "Morada")]
        public string MoradaUtilizador { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string MailUtilizador { get; set; }
    }
}
