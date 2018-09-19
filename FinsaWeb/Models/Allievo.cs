using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class Allievo
    {
        public int IdAllievo { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string TipoAllievo { get; set; }

        public ICollection<CorsoAllievo> CorsiAllievi { get; set; }
    }
}
