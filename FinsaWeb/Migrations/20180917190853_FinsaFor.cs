using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinsaWeb.Migrations
{
    public partial class FinsaFor : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allievi");
        }
    }
}
