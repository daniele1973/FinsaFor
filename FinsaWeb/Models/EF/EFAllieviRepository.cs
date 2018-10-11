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
            context.Add(Studente);
            context.SaveChanges();
        }

        public void Delete(Allievo doc)
        {
            context.Allievi.Remove(doc);
        }

        public Allievo Find(int id)
        {
            return context.Allievi.Find(id);
        }

        public IEnumerable<Allievo> FindAll()
        {
            return context.Allievi.ToList();
        }

        public IEnumerable<Allievo> FindByName(string name)
        {
            return context.Allievi.Where(x => x.Nome == name);
        }

        public void Update(Allievo doc)
        {
            context.Allievi.Update(doc);
        }
    }
}
