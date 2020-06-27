using Microsoft.EntityFrameworkCore.Migrations;

namespace SSST.Migrations
{
    public partial class UpdateModelScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guru",
                columns: table => new
                {
                    GuruID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuruNama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guru", x => x.GuruID);
                });

            migrationBuilder.CreateTable(
                name: "Kelas",
                columns: table => new
                {
                    KelasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KelasNama = table.Column<string>(nullable: true),
                    KelasTahun = table.Column<int>(nullable: false),
                    guruPengampu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelas", x => x.KelasID);
                });

            migrationBuilder.CreateTable(
                name: "MataPelajaran",
                columns: table => new
                {
                    MapelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapelNama = table.Column<string>(nullable: true),
                    GuruMapel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataPelajaran", x => x.MapelID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guru");

            migrationBuilder.DropTable(
                name: "Kelas");

            migrationBuilder.DropTable(
                name: "MataPelajaran");
        }
    }
}
