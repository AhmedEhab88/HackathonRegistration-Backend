using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCompetitorIDFromCompetitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetitorID",
                table: "Competitors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitorID",
                table: "Competitors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
