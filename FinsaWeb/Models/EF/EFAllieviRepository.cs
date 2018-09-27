using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFAllieviRepository : IAllieviRepository
    {
        private FinsaContext context;
        public EFAllieviRepository(FinsaContext ctx)
        {
            context = ctx;
        }

        public void Add(Allievo Studente)
        {
            context.Allievi.Add(Studente);
            context.SaveChanges();
        }

        public IEnumerable<Allievo> FindAll()
        {
            return context.Allievi.ToList();
        }
    }
}
