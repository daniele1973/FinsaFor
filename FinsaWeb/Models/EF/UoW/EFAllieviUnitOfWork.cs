using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF.UoW
{
    public class EFAllieviUnitOfWork : IAllieviUnitOfWork
    {
        public IAllieviRepository AllieviRepo => repo;

        public ICorsiAllieviRepository CorsiAllieviRepo => CARepo;

        private FinsaContext ctx;
        private IAllieviRepository repo;
        private ICorsiAllieviRepository CARepo;
        public EFAllieviUnitOfWork(IAllieviRepository repo, ICorsiAllieviRepository CARepo, FinsaContext ctx)
        {
            this.CARepo = CARepo;
            this.repo = repo;
            this.ctx = ctx;
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
            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DataException("errore nella update, elmento non esistente", e);
            }
        }
    }
}
