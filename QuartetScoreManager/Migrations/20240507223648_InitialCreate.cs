using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuartetScoreManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    QuartetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MusScore = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    PerScore = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    SngScore = table.Column<decimal>(type: "decimal(4,1)", nullable: false)
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
