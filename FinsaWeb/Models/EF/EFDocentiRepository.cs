using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFDocentiRepository : IDocentiRepository
    {
        private FinsaContext context;

        public EFDocentiRepository(FinsaContext context)
        {
            this.context = context;
        }
        public IEnumerable<Docente> FindAll()
        {
            return context.Docenti.ToList();
        }
    }
}
