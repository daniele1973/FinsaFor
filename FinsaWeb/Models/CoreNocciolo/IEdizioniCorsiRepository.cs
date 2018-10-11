using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.CoreNocciolo
{
    public interface IEdizioniCorsiRepository
    {
        IEnumerable<EdizioneCorso> FindAll();
        IEnumerable<EdizioneCorso> FindByName(string s);

        EdizioneCorso Find(int id);
        void Add(EdizioneCorso edizioneCorso);
        void Update(EdizioneCorso edizioneCorso);
        void Delete(EdizioneCorso edizioneCorso);
    }
}
