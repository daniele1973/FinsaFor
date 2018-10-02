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

        public void Delete(Allievo studente)
        {
            context.Allievi.Remove(studente);
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
            return context.Allievi.Where(x => x.Nome == name).ToList();
        }

        public void Update(Allievo studente)
        {
            context.Allievi.Update(studente);
        }
    }
}
