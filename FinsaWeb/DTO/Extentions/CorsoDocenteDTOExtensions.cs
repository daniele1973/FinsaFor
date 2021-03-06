﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models;

namespace FinsaWeb.DTO.Extentions
{
    public static class CorsoDocenteDTOExtensions
    {
        public static CorsoDocenteDTO ToDTO(this CorsoDocente corsoDocente)
        {
            if (corsoDocente == null) { return null; }

            return new CorsoDocenteDTO
            {
                IdEdizioneCorso = corsoDocente.IdEdizioneCorso,
                IdDocente = corsoDocente.IdDocente,
                ValutazioneMedia = corsoDocente.ValutazioneMedia
            };
        }

        public static CorsoDocente ToCorsoDocente(this CorsoDocenteDTO cd)
        {
            return new CorsoDocente
            {
                IdDocente = cd.IdDocente,
                IdEdizioneCorso = cd.IdEdizioneCorso,
                ValutazioneMedia = cd.ValutazioneMedia
            };
        }
    }
}
