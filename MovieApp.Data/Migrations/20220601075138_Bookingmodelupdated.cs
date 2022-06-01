using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class Bookingmodelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingModel_movieModel_MovieId",
                table: "bookingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_bookingModel_theatreModel_TheatreId",
                table: "bookingModel");

            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "bookingModel",
                newName: "UId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "bookingModel",
                newName: "TId");

            migrationBuilder.RenameIndex(
                name: "IX_bookingModel_TheatreId",
                table: "bookingModel",
                newName: "IX_bookingModel_UId");

            migrationBuilder.RenameIndex(
                name: "IX_bookingModel_MovieId",
                table: "bookingModel",
                newName: "IX_bookingModel_TId");

            migrationBuilder.AddColumn<int>(
                name: "MId",
                table: "bookingModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_MId",
                table: "bookingModel",
                column: "MId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingModel_movieModel_MId",
                table: "bookingModel",
                column: "MId",
                principalTable: "movieModel",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookingModel_theatreModel_TId",
                table: "bookingModel",
                column: "TId",
                principalTable: "theatreModel",
                principalColumn: "tId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookingModel_userModel_UId",
                table: "bookingModel",
                column: "UId",
                principalTable: "userModel",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingModel_movieModel_MId",
                table: "bookingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_bookingModel_theatreModel_TId",
                table: "bookingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_bookingModel_userModel_UId",
                table: "bookingModel");

            migrationBuilder.DropIndex(
                name: "IX_bookingModel_MId",
                table: "bookingModel");

            migrationBuilder.DropColumn(
                name: "MId",
                table: "bookingModel");

            migrationBuilder.RenameColumn(
                name: "UId",
                table: "bookingModel",
                newName: "TheatreId");

            migrationBuilder.RenameColumn(
                name: "TId",
                table: "bookingModel",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_bookingModel_UId",
                table: "bookingModel",
                newName: "IX_bookingModel_TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_bookingModel_TId",
                table: "bookingModel",
                newName: "IX_bookingModel_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingModel_movieModel_MovieId",
                table: "bookingModel",
                column: "MovieId",
                principalTable: "movieModel",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookingModel_theatreModel_TheatreId",
                table: "bookingModel",
                column: "TheatreId",
                principalTable: "theatreModel",
                principalColumn: "tId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
