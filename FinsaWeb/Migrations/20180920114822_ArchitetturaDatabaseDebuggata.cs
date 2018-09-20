using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinsaWeb.Migrations
{
    public partial class ArchitetturaDatabaseDebuggata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allievi",
                columns: table => new
                {
                    IdAllievo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodiceFiscale = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    TipoAllievo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allievi", x => x.IdAllievo);
                });

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    IdCorso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Difficolta = table.Column<int>(nullable: false),
                    PrezzoBase = table.Column<decimal>(nullable: false),
                    Titolo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.IdCorso);
                });

            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    IdDocente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CF = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    DataNascita = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TipoDocente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.IdDocente);
                });

            migrationBuilder.CreateTable(
                name: "EdizioniCorsi",
                columns: table => new
                {
                    IdEdizioneCorso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    IdCorso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdizioniCorsi", x => x.IdEdizioneCorso);
                    table.ForeignKey(
                        name: "FK_EdizioniCorsi_Corsi_IdCorso",
                        column: x => x.IdCorso,
                        principalTable: "Corsi",
                        principalColumn: "IdCorso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorsiAllievi",
                columns: table => new
                {
                    IdAllievo = table.Column<int>(nullable: false),
                    IdEdizioneCorso = table.Column<int>(nullable: false),
                    Voto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsiAllievi", x => new { x.IdAllievo, x.IdEdizioneCorso });
                    table.ForeignKey(
                        name: "FK_CorsiAllievi_Allievi_IdAllievo",
                        column: x => x.IdAllievo,
                        principalTable: "Allievi",
                        principalColumn: "IdAllievo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsiAllievi_EdizioniCorsi_IdEdizioneCorso",
                        column: x => x.IdEdizioneCorso,
                        principalTable: "EdizioniCorsi",
                        principalColumn: "IdEdizioneCorso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorsiDocenti",
                columns: table => new
                {
                    IdDocente = table.Column<int>(nullable: false),
                    IdEdizioneCorso = table.Column<int>(nullable: false),
                    ValutazioneMedia = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsiDocenti", x => new { x.IdDocente, x.IdEdizioneCorso });
                    table.ForeignKey(
                        name: "FK_CorsiDocenti_Docenti_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docenti",
                        principalColumn: "IdDocente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsiDocenti_EdizioniCorsi_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "EdizioniCorsi",
                        principalColumn: "IdEdizioneCorso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorsiAllievi_IdEdizioneCorso",
                table: "CorsiAllievi",
                column: "IdEdizioneCorso");

            migrationBuilder.CreateIndex(
                name: "IX_EdizioniCorsi_IdCorso",
                table: "EdizioniCorsi",
                column: "IdCorso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsiAllievi");

            migrationBuilder.DropTable(
                name: "CorsiDocenti");

            migrationBuilder.DropTable(
                name: "Allievi");

            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropTable(
                name: "EdizioniCorsi");

            migrationBuilder.DropTable(
                name: "Corsi");
        }
    }
}
