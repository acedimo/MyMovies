using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repositories.Migrations
{
    public partial class AddedViewsPropMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Movies");
        }
    }
}
