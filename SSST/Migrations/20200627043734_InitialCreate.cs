using Microsoft.EntityFrameworkCore.Migrations;

namespace SSST.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siswa",
                columns: table => new
                {
                    SiswaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiswaNim = table.Column<string>(nullable: true),
                    SiswaNama = table.Column<string>(nullable: true),
                    SiswaAlamat = table.Column<string>(nullable: true),
                    SiswaKelas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswa", x => x.SiswaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siswa");
        }
    }
}
