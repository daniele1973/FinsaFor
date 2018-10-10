using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo.UoW
{
    public interface IEdizioniCorsiUnitOfWork : IUnitOfWork
    {
        IEdizioniCorsiRepository EdizioniCorsiRepo { get; }
        ICorsiRepository CorsiRepo { get; }
        void Add(EdizioneCorso edizioneCorso);
    }
}
