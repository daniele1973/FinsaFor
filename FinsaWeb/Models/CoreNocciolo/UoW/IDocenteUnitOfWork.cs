using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo.UoW
{
    public interface IDocenteUnitOfWork : IUnitOfWork
    {
        IDocentiRepository DocentiRepo { get; }
        ICorsiDocentiRepository CorsiDocentiRepo { get; }
        IEdizioniCorsiRepository EdizioniCorsiRepo { get; }

        CorsoDocente AssegnaDocenza(int idEdizioneCorso, int idDocente);
        CorsoDocente AssegnaValutazioneMedia(int idEdizioneCorso, int idDocente, decimal valutazioneMedia);
    }
}
