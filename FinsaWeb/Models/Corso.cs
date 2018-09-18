using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class Corso
    {
        public int Id { get; set; } // L'avevo chiamata IdCorso, ma poi facendo "dotnet ef migrations add initial" mi dava l'errore: The entity type 'Corso' requires a primary key to be defined.
        public string Titolo { get; set; }
        public decimal? PrezzoBase { get; set; }
        public int? Difficolta { get; set; }
    }
}
