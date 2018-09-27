using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface IDocentiRepository
    {
        IEnumerable<Docente> FindAll();
        IEnumerable<Docente> FindByName(string name);

        Docente Find(int id);
        void Add(Docente doc);
        bool Update(Docente doc);
        bool Delete(Docente doc);
        
    }
}
