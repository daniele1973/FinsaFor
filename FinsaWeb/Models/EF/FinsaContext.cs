using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.EF
{
    public class FinsaContext : DbContext
    {
        public FinsaContext(DbContextOptions<FinsaContext> options)
           : base(options)
        {

        }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Allievo> Allievi { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<CorsoDocente> CorsiDocenti { get; set; }
        public DbSet<CorsoAllievo> CorsiAllievi { get; set; }
        public DbSet<EdizioneCorso> EdizioniCorsi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Allievo

            modelBuilder.Entity<Allievo>()
                .HasKey(a => a.IdStudente);

            #endregion

            #region Corso

            modelBuilder.Entity<Corso>()
                .HasKey(c => c.IdCorso);

            #endregion

            #region CorsoAllievo

            modelBuilder.Entity<CorsoAllievo>()
                .HasKey(ca => new { ca.IdAllievo, ca.IdEdizioneCorso });

            modelBuilder.Entity<CorsoAllievo>()
               .HasOne(ca => ca.EdizioneCorso)
               .WithMany(ec => ec.CorsiAllievi)
               .HasForeignKey(ca => ca.IdEdizioneCorso);

            modelBuilder.Entity<CorsoAllievo>()
                .HasOne(ca => ca.Allievo)
                .WithMany(a => a.CorsiAllievi)
                .HasForeignKey(ca => ca.IdAllievo);

            #endregion

            #region CorsoDocente

            modelBuilder.Entity<CorsoDocente>()
                .HasKey(cd => new { cd.IdDocente, cd.IdEdizioneCorso });

            modelBuilder.Entity<CorsoDocente>()
                .HasOne(cd => cd.EdizioneCorso)
                .WithMany(ec => ec.CorsiDocenti)
                .HasForeignKey(cd => cd.IdDocente);

            modelBuilder.Entity<CorsoDocente>()
                .HasOne(cd => cd.Docente)
                .WithMany(d => d.CorsiDocenti)
                .HasForeignKey(cd => cd.IdDocente);

            #endregion

            #region Docente

            modelBuilder.Entity<Docente>()
                .HasKey(d => d.IdDocente);

            #endregion

            #region EdizioneCorso

            modelBuilder.Entity<EdizioneCorso>()
                .HasKey(ec => ec.IdEdizioneCorso);

            modelBuilder.Entity<EdizioneCorso>()
                .HasOne(ec => ec.Corso)
                .WithMany(c => c.EdizioniCorsi)
                .HasForeignKey(ec => ec.IdCorso);

            #endregion
        }
    }
}
