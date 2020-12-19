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
        [RegularExpression(@"^[A-Z][a-z]+(\W[A-Z][a-z]+)*")]
        public string NomeFuncionario { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string MailFuncionario { get; set; }

    }
}
