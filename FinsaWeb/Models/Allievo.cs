using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class Allievo
    {
        [Key]
        [BindNever]
        public int IdStudente { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Inserire solo Lettere")]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Inserire solo Lettere")]
        public string Cognome { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Inserire solo numeri Lettere o numeri")]
        public string CodiceFiscale { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Inserire solo Lettere")]
        public string TipoStudente { get; set; }

        public ICollection<CorsoAllievo> CorsiAllievi { get; set; }
        
    }
}
