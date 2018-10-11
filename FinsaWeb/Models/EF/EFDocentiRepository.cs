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

        public void Add(Docente doc)
        {
            this.context.Docenti.Add(doc);
        }

        public void Delete(Docente doc)
        {
            throw new NotImplementedException();
        }

        public Docente Find(int id)
        {
            return this.context.Docenti.Find(id);
        }

        public IEnumerable<Docente> FindAll()
        {
            return context.Docenti.ToList();
        }

        public IEnumerable<Docente> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Docente doc)
        {
            this.context.Docenti.Update(doc);
        }
    }
}
