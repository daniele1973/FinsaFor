using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFCorsiAllieviRepository : ICorsiAllieviRepository
    {
        private FinsaContext context;
        public EFCorsiAllieviRepository(FinsaContext context)
        {
            this.context = context;
        }
        
        public void Add(CorsoAllievo corsoAllievo)
        {
            //context.Add(corsoAllievo);

            context.SaveChanges();
        }

        public IEnumerable<CorsoAllievo> FindAll()
        {

            var risultato = context.CorsiAllievi.ToList();

            /*foreach (var item in risultato)
            {
                Console.WriteLine(item.IDAllievo);
            }*/

            return risultato;

        }
    }
}
