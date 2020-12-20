using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SafetyTourism.Models;

namespace SafetyTourism.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SafetyTourismdb context)
        {
            //context.Database.EnsureCreated();

            //Look for any Doencas.
            if (context.Doencas.Any())
            {
                return;   // DB has been seeded
            }

            var doenca = new Doenca[]
            {
                new Doenca { NomeDoenca = "Doenças do sistema respiratório" },
                new Doenca { NomeDoenca = "Doenças cardiacas" },
                new Doenca { NomeDoenca = "Doenças imunossupressoras" },
                new Doenca { NomeDoenca = "Doenças mentais" },
                new Doenca { NomeDoenca = "Doenças Oncológicas" },
                new Doenca { NomeDoenca = "Doenças do sistema circulatório" },
                new Doenca { NomeDoenca = "Doenças do sistema digestivo" },
                new Doenca { NomeDoenca = "Doenças do sistema musculoesquelético" },
                new Doenca { NomeDoenca = "Doenças da pele e tecido subcutâneo" },
                new Doenca { NomeDoenca = "Anomalias congénitas" },
            };

            foreach (Doenca s in doenca)
            {
                context.Doencas.Add(s);
            }
            context.SaveChanges();
//////////////////////////////////////////////////////////////////////////
///
            var gravidadeSurto = new GravidadeSurto[]

            {

                new GravidadeSurto { DataRegisto = DateTime.Parse("2019-10-01"), NivelGravidade="Elevado"},
                new GravidadeSurto { DataRegisto = DateTime.Parse("2020-11-02"), NivelGravidade="Médio"},
                new GravidadeSurto { DataRegisto = DateTime.Parse("2020-01-08"), NivelGravidade="Baixo"},
            };

            foreach (GravidadeSurto s in gravidadeSurto)
            {
                context.GravidadeSurtos.Add(s);
            }
            context.SaveChanges();
//////////////////////////////////////////////////////////////////////////////////


            var destinoTuristico = new DestinoTuristico[]
    
            {   
                new DestinoTuristico { NomeDestino = "Porto", DensidadeDemografica = "5 736", Pais = "Portugal",Continente = "Europa"},
                new DestinoTuristico { NomeDestino = "Lisboa", DensidadeDemografica = "5 066", Pais = "Portugal",Continente = "Europa"},
                new DestinoTuristico { NomeDestino = "Londres",DensidadeDemografica = "15 066", Pais = "Inglaterra", Continente = "Europa"},
                new DestinoTuristico { NomeDestino = "Paris",DensidadeDemografica = "14 066", Pais = "França",Continente = "Europa" },
                new DestinoTuristico { NomeDestino = "Moscovo", DensidadeDemografica = "11 066", Pais = "Russia",Continente = "Europa" },
                new DestinoTuristico {NomeDestino = "Rio de Janeiro", DensidadeDemografica = "12 086", Pais = "Brasil",Continente = "America"},
                new DestinoTuristico {NomeDestino = "Pequim",DensidadeDemografica = "12 086",Pais = "China",Continente = "Asia"}
            };


            foreach (DestinoTuristico s in destinoTuristico)
            {
                context.DestinoTuristicos.Add(s);
            }
            context.SaveChanges();

///////////////////////////////////////////////////////////////////////////////////////


            var grupoRisco = new GrupoRisco[]


            {

                 new GrupoRisco { FaixaEtaria = "Crianças", Sexo = "Masculino",Etnia = "Árabes",DoencaID = 1 },
                 new GrupoRisco {FaixaEtaria = "Menores de 18",Sexo = "Ambos",Etnia = "Asiaticos",DoencaID = 2},
                 new GrupoRisco {FaixaEtaria = "Adultos",Sexo = "Ambos",Etnia = "Indiferentes", DoencaID = 3},
                 new GrupoRisco {FaixaEtaria = "Indiferente", Sexo = "Ambos",Etnia = "Indiferentes",DoencaID = 5},
                 new GrupoRisco {FaixaEtaria = "Idosos > 70 ", Sexo = "Ambos",Etnia = "Indiferentes",DoencaID = 5}
            };

            foreach (GrupoRisco s in grupoRisco)
            {
                context.GrupoRiscos.Add(s);
            }
            context.SaveChanges();


            var sintoma = new Sintoma[]

            {
                new Sintoma { DataRegisto = DateTime.Parse("2019-01-01"), NomeSintoma = "Dor de cabeça"},
                new Sintoma { DataRegisto = DateTime.Parse("2019-01-01"), NomeSintoma = "Tosse"},
                new Sintoma { DataRegisto = DateTime.Parse("2019-01-01"), NomeSintoma = "Dificuldade em respirar" },
                new Sintoma { DataRegisto = DateTime.Parse("2019-01-01"), NomeSintoma = "Febre"}
             };

            foreach (Sintoma s in sintoma)
            {

                context.Sintomas.Add(s);
            }
            context.SaveChanges();


            var recomendacoe = new Recomendacoe[]

            {   
                new Recomendacoe { DataRegisto = DateTime.Parse("2019-01-01"), DescricaoBreve = "Social Protection Measures",  Relatorio = "Maintain at least a 1-metre distance between yourself and others to reduce your risk of infection when they cough, sneeze or speak. Maintain an even greater distance between yourself and others when indoors. The further away, the better. Make wearing a mask a normal part of being around other people. The appropriate use, storage and cleaning or disposal are essential to make masks as effective as possible."},
                new Recomendacoe { DataRegisto = DateTime.Parse("2019-01-01"), DescricaoBreve = "Hygiene Measures", Relatorio = "Clean your hands before you put your mask on, as well as before and after you take it off, and after you touch it at any time. Make sure it covers both your nose, mouth and chin. When you take off a mask, store it in a clean plastic bag, and every day either wash it if it’s a fabric mask, or dispose of a medical mask in a trash bin. Don’t use masks with valves."},
                new Recomendacoe { DataRegisto = DateTime.Parse("2019-01-01"), DescricaoBreve = "Outbreaks have been reported in restaurants", Relatorio = "Outbreaks have been reported in restaurants, choir practices, fitness classes, nightclubs, offices and places of worship where people have gathered, often in crowded indoor settings where they talk loudly, shout, breathe heavily or sing. The risks of getting COVID-19 are higher in crowded and inadequately ventilated spaces where infected people spend long periods of time together in close proximity. These environments are where the virus appears to spreads by respiratory droplets or aerosols more efficiently, so taking precautions is even more importan"},
                new Recomendacoe { DataRegisto = DateTime.Parse("2019-01-01"), DescricaoBreve = "Meet people outside", Relatorio = "Outdoor gatherings are safer than indoor ones, particularly if indoor spaces are small and without outdoor air coming in. For more information on how to hold events like family gatherings, children’s football games and family occasions, read our Q&A on small public gatherings. Avoid crowded or indoor settings but if you can’t, then take precautions:Open a window.Increase the amount of ‘natural ventilation’ when indoors.WHO has published Q&As on ventilation and air conditioning for both the general public and people who manage public spaces and buildings.Wear a mask(see above for more details)."}
             };

            foreach (Recomendacoe s in recomendacoe)
            {
                
                context.Recomendacoes.Add(s);
            }
            context.SaveChanges();


            var surtoEpidemiologico = new SurtosEpidemiologico[]

            {

            new SurtosEpidemiologico { NomeSurto = "Covid", GrauContagio = "Elevado", IndiceMortalidade = "0,1", GravidadeSurtoID = 1, RecomendacoeID =1, SintomaID=1, GrupoRiscoID=2},


                   new SurtosEpidemiologico
                   {
                   NomeSurto = "Malaria",
                   GrauContagio = "Elevado",
                   IndiceMortalidade = "0,12",
                   GravidadeSurtoID = 2,
                   RecomendacoeID =3,
                   SintomaID=3,
                   GrupoRiscoID=2
                   },

                   new SurtosEpidemiologico
                   {
                   NomeSurto = "Dengue",
                   GrauContagio = "Elevado",
                   IndiceMortalidade = "0,14",
                   GravidadeSurtoID = 3,
                   RecomendacoeID =1,
                   SintomaID=1,
                   GrupoRiscoID=1
                   }


           };

            foreach (SurtosEpidemiologico s in surtoEpidemiologico)
            {
                context.SurtosEpidemiologicos.Add(s);
            }
            context.SaveChanges();





        }
    }
}