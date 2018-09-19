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
            modelBuilder.Entity<CorsoAllievo>()
                .HasKey(ca => new { ca.IDAllievo, ca.IDEdizioneCorso });

            modelBuilder.Entity<CorsoAllievo>()
               .HasOne(ca => ca.EdizioneCorso)
               .WithMany(ec => ec.CorsiAllievi)
               .HasForeignKey(ca => ca.IDEdizioneCorso);


            modelBuilder.Entity<CorsoAllievo>()
                .HasOne(ca => ca.Allievo)
                .WithMany(a => a.CorsiAllievi)
                .HasForeignKey(ca => ca.IDAllievo);
        }
    }
}
