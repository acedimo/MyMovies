using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repositories.Migrations
{
    public partial class AddedMovieGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieGenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieGenreId",
                table: "Movies");
        }
    }
}
