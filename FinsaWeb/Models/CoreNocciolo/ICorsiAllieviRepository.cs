﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface ICorsiAllieviRepository
    {
        IEnumerable<CorsoAllievo> FindAll();
        void Add(CorsoAllievo corsoAllievo);
    }
}
