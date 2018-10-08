using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF.UoW
{
    public class EFEdizioniCorsiUnitOfWork : IEdizioniCorsiUnitOfWork
    {
        private FinsaContext ctx;
        private ICorsiRepository corsiRepo;
        private IEdizioniCorsiRepository edizioniCorsiRepo;

        public ICorsiRepository CorsiRepo => corsiRepo;
        public IEdizioniCorsiRepository EdizioniCorsiRepo => edizioniCorsiRepo;

        public EFEdizioniCorsiUnitOfWork(ICorsiRepository corsiRepo,
                                         IEdizioniCorsiRepository edizioniCorsiRepo,
                                         FinsaContext ctx)
        {
            this.ctx = ctx;
            this.corsiRepo = corsiRepo;
            this.edizioniCorsiRepo = edizioniCorsiRepo;
        }

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
    }
}
