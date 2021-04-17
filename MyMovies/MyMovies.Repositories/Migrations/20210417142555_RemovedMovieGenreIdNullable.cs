using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repositories.Migrations
{
    public partial class RemovedMovieGenreIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
