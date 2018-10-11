using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    interface AllievoUnitOfWork : IUnitOfWork
    {
        IAllieviRepository AllievoRepo { get; }
        ICorsiAllieviRepository CorsiAllieviRepo { get; }
        IEdizioniCorsiRepository EdizioniRepo { get; }
    }
}
