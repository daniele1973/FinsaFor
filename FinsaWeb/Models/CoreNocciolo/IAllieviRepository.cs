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
        IEnumerable<Corso> EnrollmentsForStudent(int id);

        void Add(Allievo Studente);
        Allievo Find(int id);
        void Update(Allievo stud);
        void Delete(int idstud);
    }
}
