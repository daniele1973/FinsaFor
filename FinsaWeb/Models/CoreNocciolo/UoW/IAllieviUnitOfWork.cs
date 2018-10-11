using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo.UoW
{
    public interface IAllieviUnitOfWork : IUnitOfWork
    {
        IAllieviRepository AllieviRepo { get; }
        ICorsiAllieviRepository MyProperty { get; set; }
    }
}
