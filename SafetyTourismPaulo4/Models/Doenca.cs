using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class Doenca
    {
        public int DoencaID { get; set; }

        [Required]
        [Display(Name = "Nome de Doença")]
        public string NomeDoenca { get; set; }

       

        public ICollection<GrupoRisco> GrupoRiscos { get; set; }

    }
}
