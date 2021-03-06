﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo.UoW
{
    public interface ICorsiUnitOfWork : IUnitOfWork
    {
        ICorsiRepository CorsiRepo { get; }
        IEdizioniCorsiRepository EdizioniCorsiRepo { get; }

        
        void AddEdizioneCorso(EdizioneCorso edizioneCorso);


    }
}
