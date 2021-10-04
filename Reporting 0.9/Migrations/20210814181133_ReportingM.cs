using Microsoft.EntityFrameworkCore.Migrations;

namespace Reporting.Migrations
{
    public partial class ReportingM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAgence_Dop_ProdsId",
                table: "ListeAgence");

            migrationBuilder.RenameColumn(
                name: "ProdsId",
                table: "ListeAgence",
                newName: "DopId");

            migrationBuilder.RenameIndex(
                name: "IX_ListeAgence_ProdsId",
                table: "ListeAgence",
                newName: "IX_ListeAgence_DopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAgence_Dop_DopId",
                table: "ListeAgence",
                column: "DopId",
                principalTable: "Dop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAgence_Dop_DopId",
                table: "ListeAgence");

            migrationBuilder.RenameColumn(
                name: "DopId",
                table: "ListeAgence",
                newName: "ProdsId");

            migrationBuilder.RenameIndex(
                name: "IX_ListeAgence_DopId",
                table: "ListeAgence",
                newName: "IX_ListeAgence_ProdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAgence_Dop_ProdsId",
                table: "ListeAgence",
                column: "ProdsId",
                principalTable: "Dop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
