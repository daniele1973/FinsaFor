using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface IAllieviRepository
    {
        IEnumerable<Allievo> FindAll();
        IEnumerable<Allievo> FindByName(string name);

        void Add(Allievo Studente);
        Allievo Find(int id);
        void Update(Allievo doc);
        void Delete(Allievo doc);
    }
}
