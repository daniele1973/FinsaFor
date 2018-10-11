using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO.Extentions
{
    public static class CorsoAllievoDTOExtention
    {
        public static CorsoAllievoDTO ToDTO(this CorsoAllievo ca)
        {
            return new CorsoAllievoDTO
            {
                IdAllievo = ca.IdAllievo,
                IdEdizioneCorso = ca.IdEdizioneCorso,
                Voto = ca.Voto
            };
        }
        public static CorsoAllievo ToCorsoAllievo(this CorsoAllievoDTO ca)
        {
            return new CorsoAllievo
            {
                IdAllievo = ca.IdAllievo,
                IdEdizioneCorso = ca.IdEdizioneCorso,
                Voto = ca.Voto
            };
        }
    }
}
