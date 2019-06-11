using Microsoft.EntityFrameworkCore.Migrations;

namespace ButterfliesHunter.Migrations
{
    public partial class img_to_fly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgURL",
                table: "Butterflies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgURL",
                table: "Butterflies");
        }
    }
}
