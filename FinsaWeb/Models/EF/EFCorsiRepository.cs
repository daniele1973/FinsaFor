using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFCorsiRepository : ICorsiRepository
    {
        private FinsaContext context;
        public EFCorsiRepository(FinsaContext context)
        {
            this.context = context;
        }

        public void Aggiungi(Corso corso)
        {
            context.Corsi.Add(corso);
            context.SaveChanges();
        }

        public IEnumerable<Corso> FindAll()
        {
            return context.Corsi.ToList();
        }
    }
}
