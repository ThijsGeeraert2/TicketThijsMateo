using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketThijsMateo.Domains.Migrations
{
    /// <inheritdoc />
    public partial class testMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Stadia_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soortplaatsen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarief = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Capaciteit = table.Column<int>(type: "int", nullable: true),
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soortplaatsen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soortplaatsen_Stadia_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zitplaatsen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RijNummer = table.Column<int>(type: "int", nullable: false),
                    ZetelNummer = table.Column<int>(type: "int", nullable: false),
                    AbbonementId = table.Column<int>(type: "int", nullable: true),
                    SoortplaatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zitplaatsen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zitplaatsen_Soortplaatsen_SoortplaatsId",
                        column: x => x.SoortplaatsId,
                        principalTable: "Soortplaatsen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonnementen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Familienaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZitplaatsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnementen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnementen_Zitplaatsen_ZitplaatsID",
                        column: x => x.ZitplaatsID,
                        principalTable: "Zitplaatsen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AankoopDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    betaald = table.Column<bool>(type: "bit", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familienaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WedstrijdId = table.Column<int>(type: "int", nullable: false),
                    ZitplaatsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Zitplaatsen_ZitplaatsId",
                        column: x => x.ZitplaatsId,
                        principalTable: "Zitplaatsen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wedstrijden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchDag = table.Column<int>(type: "int", nullable: false),
                    ThuisPloegId = table.Column<int>(type: "int", nullable: false),
                    UitPloegId = table.Column<int>(type: "int", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wedstrijden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wedstrijden_Clubs_ThuisPloegId",
                        column: x => x.ThuisPloegId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wedstrijden_Stadia_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wedstrijden_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnementen_ZitplaatsID",
                table: "Abonnementen",
                column: "ZitplaatsID",
                unique: true,
                filter: "[ZitplaatsID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_StadiumId",
                table: "Clubs",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Soortplaatsen_StadiumId",
                table: "Soortplaatsen",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_WedstrijdId",
                table: "Tickets",
                column: "WedstrijdId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ZitplaatsId",
                table: "Tickets",
                column: "ZitplaatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Wedstrijden_StadiumId",
                table: "Wedstrijden",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Wedstrijden_ThuisPloegId",
                table: "Wedstrijden",
                column: "ThuisPloegId");

            migrationBuilder.CreateIndex(
                name: "IX_Wedstrijden_TicketId",
                table: "Wedstrijden",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Zitplaatsen_SoortplaatsId",
                table: "Zitplaatsen",
                column: "SoortplaatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Wedstrijden_WedstrijdId",
                table: "Tickets",
                column: "WedstrijdId",
                principalTable: "Wedstrijden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Zitplaatsen_ZitplaatsId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Stadia_StadiumId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedstrijden_Stadia_StadiumId",
                table: "Wedstrijden");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Wedstrijden_WedstrijdId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Abonnementen");

            migrationBuilder.DropTable(
                name: "Zitplaatsen");

            migrationBuilder.DropTable(
                name: "Soortplaatsen");

            migrationBuilder.DropTable(
                name: "Stadia");

            migrationBuilder.DropTable(
                name: "Wedstrijden");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
