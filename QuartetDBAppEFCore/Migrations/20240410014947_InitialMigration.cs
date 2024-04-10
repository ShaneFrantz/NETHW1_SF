using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuartetDBAppEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuartetScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuartetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusScore = table.Column<int>(type: "int", nullable: false),
                    PerScore = table.Column<int>(type: "int", nullable: false),
                    SngScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuartetScores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuartetScores");
        }
    }
}
