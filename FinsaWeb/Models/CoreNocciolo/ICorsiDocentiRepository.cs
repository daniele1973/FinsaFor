using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface ICorsiDocentiRepository
    {
        IEnumerable<CorsoDocente> FindAll();
        //IEnumerable<CorsoDocente> FindByName(string s);
        CorsoDocente Find(int idEdizioneCorso, int idDocente);

        void Add(CorsoDocente corsoDocente);
        void Update(CorsoDocente corsoDocente);
        void Delete(CorsoDocente corsoDocente);
    }
}
