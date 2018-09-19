using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class Corso
    {   [BindNever]
        public int Id { get; set; } // L'avevo chiamata IdCorso, ma poi facendo "dotnet ef migrations add initial" mi dava l'errore: The entity type 'Corso' requires a primary key to be defined.

        [Required]
        [StringLength(50, ErrorMessage ="Il titolo è obbligatorio e deve essere al massimo 50 carattere")]
        public string Titolo { get; set; }

        [Required]
        [RegularExpression(@"^[0-9,\.]+$", ErrorMessage="Inserire solo numeri")]
        public decimal? PrezzoBase { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Inserire solo numeri INTERI")]
        public int? Difficolta { get; set; }
    }
}
