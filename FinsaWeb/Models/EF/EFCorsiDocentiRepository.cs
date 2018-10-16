using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class EFCorsiDocentiRepository : ICorsiDocentiRepository
    {
        private FinsaContext context;

        public EFCorsiDocentiRepository(FinsaContext context)
        {
            this.context = context;
        }

        public IEnumerable<CorsoDocente> FindAll()
        {
            return context.CorsiDocenti.ToList(); // CorsiDocenti non lo prende
        }

        public void Add(CorsoDocente corsoDocente)
        {
            context.CorsiDocenti.Add(corsoDocente);
            context.SaveChanges();
        }

        //public void Add(CorsoAllievo corsoAllievo)
        //{
        //    context.CorsiAllievi.Add(corsoAllievo);

        //    context.SaveChanges();

            void ICorsiDocentiRepository.Delete(CorsoDocente corsoDocente)
        {
            throw new NotImplementedException();
        }

        CorsoDocente ICorsiDocentiRepository.Find(int idEdizioneCorso, int idDocente)
        {
            return context.CorsiDocenti.Find(idEdizioneCorso,idDocente);
        }

        IEnumerable<CorsoDocente> ICorsiDocentiRepository.FindAll()
        {
            throw new NotImplementedException();
        }

        //IEnumerable<CorsoDocente> ICorsiDocentiRepository.FindByName(string s)
        //{
        //    throw new NotImplementedException();
        //}

        void ICorsiDocentiRepository.Update(CorsoDocente corsoDocente)
        {
            throw new NotImplementedException();
        }
    }
}
