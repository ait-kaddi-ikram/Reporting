using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reporting.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAgence_Dop_DopId",
                table: "ListeAgence");

            migrationBuilder.DropIndex(
                name: "IX_ListeAgence_DopId",
                table: "ListeAgence");

            migrationBuilder.DropColumn(
                name: "DopId",
                table: "ListeAgence");

            migrationBuilder.AlterColumn<decimal>(
                name: "MNT_FACT",
                table: "WaFacs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_MAJ",
                table: "WaFacs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_DOP",
                table: "ListeAgence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Dop",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "wa_cat_abt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libcateg_abt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wa_cat_abt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "wa_fraudes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_FAC_CLI = table.Column<int>(type: "int", nullable: false),
                    DAT_FAC_CLI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_EXG_FAC_CLI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TYP_FACT_ORI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUM_CTA_ABT = table.Column<int>(type: "int", nullable: false),
                    NUM_TRN_RLV_ABT = table.Column<int>(type: "int", nullable: false),
                    LIB_TRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIB_CAT_ABT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUM_CLI = table.Column<int>(type: "int", nullable: false),
                    RAI_SOC_CLI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNO_CLI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPG_APT_PNT_DRT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COORD_X = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COORD_Y = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNT_FAC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LATI_LONG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MNT_AV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MNT_FAC_AV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QTE = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wa_fraudes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListeAgence_Id_DOP",
                table: "ListeAgence",
                column: "Id_DOP");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAgence_Dop_Id_DOP",
                table: "ListeAgence",
                column: "Id_DOP",
                principalTable: "Dop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAgence_Dop_Id_DOP",
                table: "ListeAgence");

            migrationBuilder.DropTable(
                name: "wa_cat_abt");

            migrationBuilder.DropTable(
                name: "wa_fraudes");

            migrationBuilder.DropIndex(
                name: "IX_ListeAgence_Id_DOP",
                table: "ListeAgence");

            migrationBuilder.DropColumn(
                name: "Id_DOP",
                table: "ListeAgence");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Dop");

            migrationBuilder.AlterColumn<decimal>(
                name: "MNT_FACT",
                table: "WaFacs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATE_MAJ",
                table: "WaFacs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DopId",
                table: "ListeAgence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListeAgence_DopId",
                table: "ListeAgence",
                column: "DopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAgence_Dop_DopId",
                table: "ListeAgence",
                column: "DopId",
                principalTable: "Dop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
