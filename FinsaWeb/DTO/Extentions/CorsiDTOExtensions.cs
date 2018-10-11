using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO.Extentions
{
    public static class CorsoDTOExtensions
    {
        public static CorsoDTO ToDTO(this Corso corso)
        {
            if (corso==null) { return null; }

            return new CorsoDTO
            {
                IdCorso = corso.IdCorso,
                Difficolta=corso.Difficolta,
                PrezzoBase=corso.PrezzoBase,
                Titolo=corso.Titolo
            };
        }
    }
}
