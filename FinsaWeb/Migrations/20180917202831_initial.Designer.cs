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
    [Migration("20180917202831_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinsaWeb.Models.Corso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Difficolta");

                    b.Property<decimal?>("PrezzoBase");

                    b.Property<string>("Titolo");

                    b.HasKey("Id");

                    b.ToTable("Corsi");
                });
#pragma warning restore 612, 618
        }
    }
}
