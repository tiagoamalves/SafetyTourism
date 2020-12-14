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

            /* Look for any students.
            if (context.Doencas.Any())
            {
                return;   // DB has been seeded
            }*/

            var doencas = new Doenca[]
            {
                new Doenca { NomeDoenca = "Malaria" },
            };

            context.Doencas.AddRange(doencas);
            context.SaveChanges();
        }
    }
}