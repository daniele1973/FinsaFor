using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models
{
    public class ControlloAllievi
    {
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Inserire solo Numeri")]
        public int IdStudente { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Inserire solo Lettere")]
        public string NomeStudente { get; set; }
    }
}
