﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface IDocentiRepository
    {
        IEnumerable<Docente> FindAll();
    }
}