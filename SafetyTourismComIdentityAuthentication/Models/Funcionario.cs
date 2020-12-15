using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourism.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string NomeFuncionario { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string MailFuncionario { get; set; }

    }
}
