using Microsoft.EntityFrameworkCore.Migrations;

namespace SSST.Migrations
{
    public partial class UpdateFieldGradeMapel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapelGrade",
                table: "MataPelajaran",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapelGrade",
                table: "MataPelajaran");
        }
    }
}
