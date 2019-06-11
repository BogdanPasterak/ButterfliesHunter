using Microsoft.EntityFrameworkCore.Migrations;

namespace ButterfliesHunter.Migrations
{
    public partial class img_to_fly2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgURL",
                table: "Butterflies",
                newName: "ImgURL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgURL",
                table: "Butterflies",
                newName: "imgURL");
        }
    }
}
