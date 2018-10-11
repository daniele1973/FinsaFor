using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO
{
    public class CorsoAllievoDTO
    {
        public int IdAllievo { get; set; }
        public int IdEdizioneCorso { get; set; }
        public int? Voto { get; set; }
    }
}
