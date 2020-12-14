using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SafetyTourism.Models;

namespace SafetyTourism.Data
{
    public static class PreDados
    {
        public static void Initialize(SafetyTourismdb context)
        {
            //context.Database.EnsureCreated();

            //Look for any Doencas.
            if (context.Doencas.Any())
            {
                return;   // DB has been seeded
            }
          
                var doencas = new Doenca[]
            {
                new Doenca { NomeDoenca = "Malaria", },
                new Doenca { NomeDoenca = "Tuberculose", },
            };
            foreach (Doenca i in doencas)
            {
                context.Doencas.AddRange(doencas);
            }
            context.SaveChanges();


            var destinoTuristico = new DestinoTuristico[]
            {
                new DestinoTuristico { NomeDestino = "Porto", DensidadeDemografica="445", Pais="Portugal", Continente="Europa" },
                new DestinoTuristico { NomeDestino = "Lisboa", DensidadeDemografica="635", Pais="Portugal", Continente="Europa" },
            };
            foreach (DestinoTuristico i in destinoTuristico)
            {
                context.DestinoTuristicos.AddRange(destinoTuristico);
            }
            context.SaveChanges();


            var funcionarios = new Funcionario[]
            {
                new Funcionario { NomeFuncionario = "Leandro", MailFuncionario="leandro@st.pt" },
                new Funcionario { NomeFuncionario = "Paulo", MailFuncionario="paulo@st.pt" },
                new Funcionario { NomeFuncionario = "Pedro", MailFuncionario="pedro@st.pt" },
                new Funcionario { NomeFuncionario = "Tiago", MailFuncionario="tiago@st.pt" },
                new Funcionario { NomeFuncionario = "Victor", MailFuncionario="victor@st.pt" },
            };
            foreach (Funcionario i in funcionarios)
            {
                context.Funcionarios.AddRange(funcionarios);
            }
            context.SaveChanges();


        }
    }
}