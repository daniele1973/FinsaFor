using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb
{
    internal class EFEdizioniCorsiRepository : IEdizioniCorsiRepository
    {
        private FinsaContext context;

        public EFEdizioniCorsiRepository(FinsaContext context)
        {
            this.context = context;
        }

        public void Aggiungi(EdizioneCorso edizioneCorso)
        {
            throw new NotImplementedException("PLUTO");
        }

        public IEnumerable<EdizioneCorso> FindAll()
        {
            return context.EdizioniCorsi.ToList();
        }
    }
}