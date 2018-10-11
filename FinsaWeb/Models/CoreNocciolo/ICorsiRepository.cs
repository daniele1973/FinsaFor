using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface ICorsiRepository
    {
        IEnumerable<Corso> FindAll();
        IEnumerable<Corso> FindByName(string s);
        Corso Find(int id);

        void Add(Corso corso);
        void Update(Corso corso);
        void Delete(Corso corso);
    }
}
