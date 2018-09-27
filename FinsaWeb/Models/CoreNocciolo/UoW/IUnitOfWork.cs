using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo.UoW
{
    public interface IUnitOfWork
    {
        void Begin();
        void End();
        void Save();
        void Cancel();
    }
}
