using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class CorsoDocente
    {
        public int IdDocente { get; set; }
        public int IdEdizioneCorso { get; set; }
        public decimal ValutazioneMedia { get; set; }

        public Docente Docente { get; set; }
        public EdizioneCorso EdizioneCorso { get; set; }
    }
}
