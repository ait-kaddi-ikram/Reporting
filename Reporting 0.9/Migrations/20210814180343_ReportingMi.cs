using Microsoft.EntityFrameworkCore.Migrations;

namespace Reporting.Migrations
{
    public partial class ReportingMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAgence_Prods_ProdsId",
                table: "ListeAgence");

            migrationBuilder.DropTable(
                name: "Prods");

            migrationBuilder.CreateTable(
                name: "Dop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libele = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dop", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAgence_Dop_ProdsId",
                table: "ListeAgence",
                column: "ProdsId",
                principalTable: "Dop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAgence_Dop_ProdsId",
                table: "ListeAgence");

            migrationBuilder.DropTable(
                name: "Dop");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAgence_Prods_ProdsId",
                table: "ListeAgence",
                column: "ProdsId",
                principalTable: "Prods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
