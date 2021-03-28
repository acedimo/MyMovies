using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repositories.Migrations
{
    public partial class AddedDateModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Movies");
        }
    }
}
