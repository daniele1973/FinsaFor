using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class EdizioneCorso
    {
        public int Id { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataInizio { get; set; }
        public IEnumerable<CorsoAllievo> CorsiAllievi { get; set; }
    }
}
