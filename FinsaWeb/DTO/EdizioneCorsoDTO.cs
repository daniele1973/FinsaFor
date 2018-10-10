using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO
{
    public class EdizioneCorsoDTO
    {
        public int IdEdizioneCorso { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataInizio { get; set; }
        public Corso Corso { get; set; }
    }
}
