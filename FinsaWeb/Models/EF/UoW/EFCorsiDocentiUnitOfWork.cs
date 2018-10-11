using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using Microsoft.EntityFrameworkCore;

namespace FinsaWeb.Models.EF.UoW
{
    public class EFCorsiDocentiUnitOfWork : ICorsiDocentiRepository
    {
        public void Add(CorsoDocente corsoDocente)
        {
            throw new NotImplementedException();
        }

        public void Delete(CorsoDocente corsoDocente)
        {
            throw new NotImplementedException();
        }

        public CorsoDocente Find(int idEdizioneCorso, int idDocente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CorsoDocente> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CorsoDocente> FindByName(string s)
        {
            throw new NotImplementedException();
        }

        public void Update(CorsoDocente corsoDocente)
        {
            throw new NotImplementedException();
        }
    }
}
