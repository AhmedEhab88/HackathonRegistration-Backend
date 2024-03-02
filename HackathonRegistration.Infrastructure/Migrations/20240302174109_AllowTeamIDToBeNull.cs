using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllowTeamIDToBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Teams_TeamID",
                table: "Competitors");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Competitors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Teams_TeamID",
                table: "Competitors",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Teams_TeamID",
                table: "Competitors");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Competitors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Teams_TeamID",
                table: "Competitors",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
