﻿using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFCorsiDocentiRepository : ICorsiDocentiRepository
    {
        public IEnumerable<Docente> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
