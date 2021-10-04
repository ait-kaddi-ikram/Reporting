using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reporting.Migrations
{
    public partial class ReportingMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libele = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaFacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMTRN = table.Column<int>(type: "int", nullable: true),
                    AGCTRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIBCATEG_ABT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CAT_ABT = table.Column<int>(type: "int", nullable: true),
                    DAT_FACT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TYP_FACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TYP_FACT_REF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ETA_FACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAT_EXG_FACT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MNT_FACT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DATE_MAJ = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaFacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListeAgence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeAgence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListeAgence_Prods_ProdsId",
                        column: x => x.ProdsId,
                        principalTable: "Prods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListeAgence_ProdsId",
                table: "ListeAgence",
                column: "ProdsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListeAgence");

            migrationBuilder.DropTable(
                name: "WaFacs");

            migrationBuilder.DropTable(
                name: "Prods");
        }
    }
}
