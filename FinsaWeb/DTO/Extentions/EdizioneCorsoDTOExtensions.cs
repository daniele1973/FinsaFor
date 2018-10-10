using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO.Extentions
{
    public static class EdizioneCorsoDTOExtensions
    {
        public static EdizioneCorsoDTO ToDTO(this EdizioneCorso edizioneCorso)
        {
            if (edizioneCorso == null) { return null; }

            return new EdizioneCorsoDTO
            {
                IdEdizioneCorso = edizioneCorso.IdEdizioneCorso,
                IdCorso = edizioneCorso.IdCorso,
                DataInizio = edizioneCorso.DataInizio
            };
        }

        public static EdizioneCorso ToEdizioneCorso(this EdizioneCorsoDTO edizioneCorsoDTO)
        {
            if (edizioneCorsoDTO == null) { return null; }

            return new EdizioneCorso
            {
                IdEdizioneCorso = edizioneCorsoDTO.IdEdizioneCorso,
                IdCorso = edizioneCorsoDTO.IdCorso,
                DataInizio = edizioneCorsoDTO.DataInizio
            };
        }
    }
}
