using FinsaWeb.Models.CoreNocciolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.InMemory
{
    public class InMemoryStudentRepository : IAllieviRepository
    {

        private static List<Allievo> listaAllievi = new List<Allievo>
        {
            new Allievo
            {
                IdStudente=1,
                Nome = "Italo",
                Cognome="Calvino",
                CodiceFiscale="ITLCLV44A35D969M",
                TipoStudente="Cantastorie"
            },
             new Allievo
            {
                IdStudente=2,
                Nome="Ibrahimovich",
                Cognome="Slatan",
                CodiceFiscale="IHVSLT86A24D756M",
                TipoStudente = "Pallonaro"
            }

        };

        public void Add(Allievo Studente)
        {
            listaAllievi.Add(Studente);
        }

        public void Delete(Allievo doc)
        {
            throw new NotImplementedException();
        }

        public Allievo Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Allievo> FindAll()
        {
            //List<Course> lista = new List<Course>();
            //for (int i = 0; i < courses.Count; i++)
            //{
            //    if (courses[i].Title.Contains(title))
            //    {
            //        lista.Add(courses[i]);
            //    }

            //}
            //return lista;
            //return courses.Where(c => c.Title.Contains(title));
            return listaAllievi;
        }

        public IEnumerable<Allievo> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Allievo doc)
        {
            throw new NotImplementedException();
        }
    }
}
