using Microsoft.EntityFrameworkCore.Migrations;

namespace NamaShow.DataLayer.Migrations
{
    public partial class Mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Slides");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Slides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Slides_MovieId",
                table: "Slides",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Movies_MovieId",
                table: "Slides",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Movies_MovieId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_Slides_MovieId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Slides");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
