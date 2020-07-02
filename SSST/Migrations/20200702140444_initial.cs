using Microsoft.EntityFrameworkCore.Migrations;

namespace SSST.Migrations
{
    public partial class initial : Migration
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
                    KelasTingkat = table.Column<int>(nullable: false),
                    KelasTahun = table.Column<int>(nullable: false),
                    GuruID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelas", x => x.KelasID);
                    table.ForeignKey(
                        name: "FK_Kelas_Guru_GuruID",
                        column: x => x.GuruID,
                        principalTable: "Guru",
                        principalColumn: "GuruID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MataPelajaran",
                columns: table => new
                {
                    MapelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapelNama = table.Column<string>(nullable: true),
                    MapelDesc = table.Column<string>(nullable: true),
                    MapelGrade = table.Column<int>(nullable: false),
                    GuruID = table.Column<int>(nullable: false),
                    KelasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataPelajaran", x => x.MapelID);
                    table.ForeignKey(
                        name: "FK_MataPelajaran_Guru_GuruID",
                        column: x => x.GuruID,
                        principalTable: "Guru",
                        principalColumn: "GuruID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MataPelajaran_Kelas_KelasID",
                        column: x => x.KelasID,
                        principalTable: "Kelas",
                        principalColumn: "KelasID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Siswa",
                columns: table => new
                {
                    SiswaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiswaNim = table.Column<string>(maxLength: 12, nullable: true),
                    SiswaNama = table.Column<string>(nullable: true),
                    SiswaAlamat = table.Column<string>(nullable: true),
                    KelasID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswa", x => x.SiswaID);
                    table.ForeignKey(
                        name: "FK_Siswa_Kelas_KelasID",
                        column: x => x.KelasID,
                        principalTable: "Kelas",
                        principalColumn: "KelasID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiswaNilai",
                columns: table => new
                {
                    SiswaID = table.Column<int>(nullable: false),
                    MapelID = table.Column<int>(nullable: false),
                    Nilai = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiswaNilai", x => new { x.SiswaID, x.MapelID });
                    table.ForeignKey(
                        name: "FK_SiswaNilai_MataPelajaran_MapelID",
                        column: x => x.MapelID,
                        principalTable: "MataPelajaran",
                        principalColumn: "MapelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiswaNilai_Siswa_SiswaID",
                        column: x => x.SiswaID,
                        principalTable: "Siswa",
                        principalColumn: "SiswaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kelas_GuruID",
                table: "Kelas",
                column: "GuruID");

            migrationBuilder.CreateIndex(
                name: "IX_MataPelajaran_GuruID",
                table: "MataPelajaran",
                column: "GuruID");

            migrationBuilder.CreateIndex(
                name: "IX_MataPelajaran_KelasID",
                table: "MataPelajaran",
                column: "KelasID");

            migrationBuilder.CreateIndex(
                name: "IX_Siswa_KelasID",
                table: "Siswa",
                column: "KelasID");

            migrationBuilder.CreateIndex(
                name: "IX_SiswaNilai_MapelID",
                table: "SiswaNilai",
                column: "MapelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiswaNilai");

            migrationBuilder.DropTable(
                name: "MataPelajaran");

            migrationBuilder.DropTable(
                name: "Siswa");

            migrationBuilder.DropTable(
                name: "Kelas");

            migrationBuilder.DropTable(
                name: "Guru");
        }
    }
}
