﻿// <auto-generated />
using FinsaWeb.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FinsaWeb.Migrations
{
    [DbContext(typeof(FinsaContext))]
    partial class FinsaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CorsoAllievo", b =>
                {
                    b.Property<int>("IDAllievo");

                    b.Property<int>("IDEdizioneCorso");

                    b.Property<int?>("Voto");

                    b.HasKey("IDAllievo", "IDEdizioneCorso");

                    b.HasIndex("IDEdizioneCorso");

                    b.ToTable("CorsiAllievi");
                });

            modelBuilder.Entity("FinsaWeb.Models.Allievo", b =>
                {
                    b.Property<int>("IdAllievo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodiceFiscale");

                    b.Property<string>("Cognome");

                    b.Property<string>("Nome");

                    b.Property<string>("TipoAllievo");

                    b.HasKey("IdAllievo");

                    b.ToTable("Allievi");
                });

            modelBuilder.Entity("FinsaWeb.Models.Corso", b =>
                {
                    b.Property<int>("IdCorso")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Difficolta")
                        .IsRequired();

                    b.Property<decimal?>("PrezzoBase")
                        .IsRequired();

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdCorso");

                    b.ToTable("Corsi");
                });

            modelBuilder.Entity("FinsaWeb.Models.CorsoDocente", b =>
                {
                    b.Property<int>("IdDocente");

                    b.Property<int>("IdEdizioneCorso");

                    b.Property<decimal>("ValutazioneMedia");

                    b.HasKey("IdDocente", "IdEdizioneCorso");

                    b.ToTable("CorsiDocenti");
                });

            modelBuilder.Entity("FinsaWeb.Models.Docente", b =>
                {
                    b.Property<int>("IdDocente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CF");

                    b.Property<string>("Cognome");

                    b.Property<DateTime>("DataNascita");

                    b.Property<string>("Nome");

                    b.Property<string>("TipoDocente");

                    b.HasKey("IdDocente");

                    b.ToTable("Docenti");
                });

            modelBuilder.Entity("FinsaWeb.Models.EdizioneCorso", b =>
                {
                    b.Property<int>("IdEdizioneCorso")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataInizio");

                    b.Property<int>("IdCorso");

                    b.HasKey("IdEdizioneCorso");

                    b.HasIndex("IdCorso");

                    b.ToTable("EdizioniCorsi");
                });

            modelBuilder.Entity("CorsoAllievo", b =>
                {
                    b.HasOne("FinsaWeb.Models.Allievo", "Allievo")
                        .WithMany("CorsiAllievi")
                        .HasForeignKey("IDAllievo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinsaWeb.Models.EdizioneCorso", "EdizioneCorso")
                        .WithMany("CorsiAllievi")
                        .HasForeignKey("IDEdizioneCorso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinsaWeb.Models.CorsoDocente", b =>
                {
                    b.HasOne("FinsaWeb.Models.Docente", "Docente")
                        .WithMany("CorsiDocenti")
                        .HasForeignKey("IdDocente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinsaWeb.Models.EdizioneCorso", "EdizioneCorso")
                        .WithMany("CorsiDocenti")
                        .HasForeignKey("IdDocente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinsaWeb.Models.EdizioneCorso", b =>
                {
                    b.HasOne("FinsaWeb.Models.Corso", "Corso")
                        .WithMany("EdizioniCorsi")
                        .HasForeignKey("IdCorso")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
