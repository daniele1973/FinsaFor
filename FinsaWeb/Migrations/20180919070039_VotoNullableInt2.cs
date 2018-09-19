using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinsaWeb.Migrations
{
    public partial class VotoNullableInt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allievi",
                columns: table => new
                {
                    IdStudente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodiceFiscale = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    TipoStudente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allievi", x => x.IdStudente);
                });

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Difficolta = table.Column<int>(nullable: true),
                    PrezzoBase = table.Column<decimal>(nullable: true),
                    Titolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorsiDocenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsiDocenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    IDDocente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CF = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    DataNascita = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TipoDocente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.IDDocente);
                });

            migrationBuilder.CreateTable(
                name: "EdizioniCorsi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    IdCorso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdizioniCorsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorsiAllievi",
                columns: table => new
                {
                    IDAllievo = table.Column<int>(nullable: false),
                    IDEdizioneCorso = table.Column<int>(nullable: false),
                    Voto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsiAllievi", x => new { x.IDAllievo, x.IDEdizioneCorso });
                    table.ForeignKey(
                        name: "FK_CorsiAllievi_Allievi_IDAllievo",
                        column: x => x.IDAllievo,
                        principalTable: "Allievi",
                        principalColumn: "IdStudente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsiAllievi_EdizioniCorsi_IDEdizioneCorso",
                        column: x => x.IDEdizioneCorso,
                        principalTable: "EdizioniCorsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorsiAllievi_IDEdizioneCorso",
                table: "CorsiAllievi",
                column: "IDEdizioneCorso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "CorsiAllievi");

            migrationBuilder.DropTable(
                name: "CorsiDocenti");

            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropTable(
                name: "Allievi");

            migrationBuilder.DropTable(
                name: "EdizioniCorsi");
        }
    }
}
