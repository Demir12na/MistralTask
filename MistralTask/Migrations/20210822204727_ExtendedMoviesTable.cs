using Microsoft.EntityFrameworkCore.Migrations;

namespace MistralTask.Migrations
{
    public partial class ExtendedMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiveStars",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FourStars",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OneStars",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThreeStars",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TwoStars",
                table: "Movies",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiveStars",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FourStars",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "OneStars",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ThreeStars",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TwoStars",
                table: "Movies");
        }
    }
}
