using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.EF;
using FinsaWeb.Models.EF.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb
{
    internal class EFEdizioniCorsiRepository : IEdizioniCorsiRepository
    {
        private FinsaContext ctx;

        public EFEdizioniCorsiRepository(FinsaContext ctx)
        {
            this.ctx = ctx;
        }

        public EdizioneCorso Find(int id)
        {
            return ctx.EdizioniCorsi.Find(id);
        }

        public IEnumerable<EdizioneCorso> FindAll()
        {
            return ctx.EdizioniCorsi.ToList();
        }

        public IEnumerable<EdizioneCorso> FindByName(string s)
        {
            return ctx.EdizioniCorsi.Where(ec=>ec.Corso.Titolo.Contains(s)).ToList();
        }

        public void Add(EdizioneCorso edizioneCorso)
        {
            ctx.EdizioniCorsi.Add(edizioneCorso);
        }

        public void Delete(EdizioneCorso edizioneCorso)
        {
            ctx.EdizioniCorsi.Remove(edizioneCorso);
        }

        public void Update(EdizioneCorso edizioneCorso)
        {
            ctx.EdizioniCorsi.Update(edizioneCorso);
        }
    }
}