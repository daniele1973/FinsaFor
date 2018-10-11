using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO
{
    public class CorsoDTO
    {
        public int IdCorso { get; set; }
        public decimal? PrezzoBase { get; set; }
        public int? Difficolta { get; set; }
        public string Titolo { get; set; }

    }
}
