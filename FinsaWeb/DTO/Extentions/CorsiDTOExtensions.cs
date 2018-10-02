using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO.Extentions
{
    public static class CorsiDTOExtensions
    {
        public static CorsiDTO ToDTO(this Corso corso)
        {
            return new CorsiDTO
            {
                IdCorso = corso.IdCorso,
                Difficolta=corso.Difficolta,
                PrezzoBase=corso.PrezzoBase,
                Titolo=corso.Titolo
            };
        }
    }
}
