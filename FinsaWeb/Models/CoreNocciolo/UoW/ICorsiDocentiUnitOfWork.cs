using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo.UoW
{
    interface ICorsiDocentiUnitOfWork : IUnitOfWork
    {
        ICorsiDocentiRepository CorsiDocenti { get; }
    }
}
