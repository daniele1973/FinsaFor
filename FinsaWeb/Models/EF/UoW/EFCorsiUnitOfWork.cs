﻿using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF.UoW
{
    public class EFCorsiUnitOfWork : ICorsiUnitOfWork
    {
        public ICorsiRepository CorsiRepo => throw new NotImplementedException();

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void End()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
