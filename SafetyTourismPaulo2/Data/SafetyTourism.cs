using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafetyTourismPaulo.Models;
using Microsoft.EntityFrameworkCore;

namespace SafetyTourismPaulo.Data
{
    public class SafetyTourism : DbContext
    {
        public SafetyTourism(DbContextOptions<SafetyTourism> options) : base(options)
        {
        }

        public DbSet<SurtosEpidemiologico> SurtosEpidemiologico { get; set; }
        public DbSet<DestinoTuristico> DestinoTuristico { get; set; }
        public DbSet<SurtosOcurrencia> SurtosOcurrencias { get; set; }
        public DbSet<Doenca> Doencas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<GravidadeSurto> GravidadeSurtos { get; set; }
        public DbSet<GrupoRisco> GrupoRiscos { get; set; }
        public DbSet<Recomendacoe> Recomendacoes { get; set; }
        public DbSet<Sintoma> Sintomas { get; set; }
        public DbSet<Utilizador> Utilizadors { get; set; }
        }
}
