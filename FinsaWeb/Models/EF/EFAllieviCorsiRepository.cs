using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFCorsiAllieviRepository : ICorsiAllieviRepository
    {
        public IEnumerable<CorsoAllievo> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
