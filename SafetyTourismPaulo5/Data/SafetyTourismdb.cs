
using SafetyTourism.Models;
using Microsoft.EntityFrameworkCore;


namespace SafetyTourism.Data
{
    public class SafetyTourismdb : DbContext
    {
        
            public SafetyTourismdb(DbContextOptions<SafetyTourismdb> options) : base(options)
            {
            }

            public DbSet<DestinoTuristico> DestinoTuristicos { get; set; }
            public DbSet<Doenca> Doencas { get; set; }
            public DbSet<Funcionario> Funcionarios { get; set; }
            public DbSet<GravidadeSurto> GravidadeSurtos { get; set; }
            public DbSet<GrupoRisco> GrupoRiscos { get; set; }
            public DbSet<Recomendacoe> Recomendacoes { get; set; }
            public DbSet<Sintoma> Sintomas { get; set; }
            public DbSet<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }
            public DbSet<SurtosOcurrencia> SurtosOcurrencias { get; set; }
            public DbSet<Utilizador> Utilizadors { get; set; }

    }
}

