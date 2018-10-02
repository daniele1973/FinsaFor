using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO.Extentions
{
    public static class AllievoDTOExtention
    {
        public static Allievo ToAllievo(this AllievoDTO allievo)
        {
            return new Allievo
            {
                IdStudente = allievo.IdStudente,
                Nome = allievo.Nome,
                CodiceFiscale = allievo.CodiceFiscale,
                Cognome = allievo.Cognome,
                TipoStudente = allievo.TipoStudente
            };
        }
        public static AllievoDTO ToDTO(this Allievo allievo)
        {
            return new AllievoDTO
            {
                IdStudente = allievo.IdStudente,
                Nome = allievo.Nome,
                CodiceFiscale = allievo.CodiceFiscale,
                Cognome = allievo.Cognome,
                TipoStudente = allievo.TipoStudente
            };
        }
    }
}
