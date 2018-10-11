using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using FinsaWeb.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF.UoW
{
    public class EFCorsiUnitOfWork : ICorsiUnitOfWork
    {
        //public ICorsiRepository CorsiRepo => throw new NotImplementedException();

        //public IEdizioniCorsiRepository EdizioniCorsi => throw new NotImplementedException();

        private FinsaContext ctx;
        private ICorsiRepository corsiRepo;
        private IEdizioniCorsiRepository edizioniCorsiRepo;

        public ICorsiRepository CorsiRepo => corsiRepo;
        public IEdizioniCorsiRepository EdizioniCorsiRepo => edizioniCorsiRepo;



        public EFCorsiUnitOfWork(ICorsiRepository corsiRepo,
                                         IEdizioniCorsiRepository edizioniCorsiRepo,
                                         FinsaContext ctx)
        {
            this.ctx = ctx;
            this.corsiRepo = corsiRepo;
            this.edizioniCorsiRepo = edizioniCorsiRepo;
        }



        public IEdizioniCorsiRepository EdizioniCorsi => throw new NotImplementedException();

        public void Begin()
        {
            ctx.Database.BeginTransaction();
        }

        public void Cancel()
        {
            ctx.Database.RollbackTransaction();
        }

        public void End()
        {
            ctx.Database.CommitTransaction();
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void AddEdizioneCorso(EdizioneCorso edizioneCorso)
        {
            Console.Error.WriteLine("AAAAAAA");

            try
            {
                ctx.Database.BeginTransaction();
                edizioniCorsiRepo.Add(edizioneCorso);
                ctx.SaveChanges();
                ctx.Database.CommitTransaction();
            }
            catch (DbUpdateException e)
            {
                ctx.Database.RollbackTransaction();
                throw new BusinessLogicException("Errore nell'inserimento EDIZIONE CORSO", e);

            }
        }
    }
}
