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
        void Aggiungi(Corso corso);
    }
}
