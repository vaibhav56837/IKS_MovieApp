using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class bookingModelCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingModel",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingModel", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_bookingModel_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModel_theatreModel_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModel",
                        principalColumn: "tId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_MovieId",
                table: "bookingModel",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_TheatreId",
                table: "bookingModel",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingModel");
        }
    }
}
