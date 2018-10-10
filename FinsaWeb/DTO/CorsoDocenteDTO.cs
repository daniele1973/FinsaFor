using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO
{
    public class CorsoDocenteDTO
    {
        public int IdDocente { get; set; }
        public int IdEdizioneCorso { get; set; }
        public decimal ValutazioneMedia { get; set; }
    }
}
