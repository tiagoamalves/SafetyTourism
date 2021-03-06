﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourism.Models
{
    public class GrupoRisco
    {
        public int GrupoRiscoID { get; set; }
        public string FaixaEtaria { get; set; }
        public string Sexo { get; set; }
        public string Etnia { get; set; }
        public int DoencaID { get; set; }

        public Doenca Doenca { get; set; }
        public ICollection<SurtosEpidemiologico> SurtosEpidemiologicos { get; set; }

    }
}
