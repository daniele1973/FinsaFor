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

        Allievo Find(int id);
        void Add(Allievo Studente);
        void Update(Allievo doc);
        void Delete(Allievo doc);
    }
}
