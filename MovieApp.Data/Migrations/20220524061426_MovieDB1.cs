using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class MovieDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "theatreModel",
                columns: table => new
                {
                    tId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tCapacity = table.Column<int>(type: "int", nullable: false),
                    tClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theatreModel", x => x.tId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "theatreModel");
        }
    }
}
