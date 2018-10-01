using FinsaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.DTO.Extentions
{
    public static class DocenteDTOExtentions
    {
        public static DocenteDTO ToDTO(this Docente doc)
        {
            return new DocenteDTO
            {
                IdDocente = doc.IdDocente,
                CF=doc.CF,
                Cognome= doc.Cognome,
                DataNascita= doc.DataNascita,
                Nome=doc.Nome,
                TipoDocente=doc.TipoDocente
            };
        }

        public static Docente ToDocente(this DocenteDTO dto)
        {
            return new Docente
            {
                IdDocente = dto.IdDocente,
                CF = dto.CF,
                Cognome = dto.Cognome,
                DataNascita = dto.DataNascita,
                Nome = dto.Nome,
                TipoDocente = dto.TipoDocente
            };
        }
    }
}
