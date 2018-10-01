using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class Docente
    {
        public int IdDocente { get; set; }
        public string CF { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string TipoDocente { get; set; }

        public ICollection<CorsoDocente> CorsiDocenti { get; set; }
    }
}
