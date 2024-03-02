using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialModelsSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    ChallengeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.ChallengeID);
                });

            migrationBuilder.CreateTable(
                name: "Hackathons",
                columns: table => new
                {
                    HackathonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaximumTeamSize = table.Column<int>(type: "int", nullable: false),
                    MaximumNumberOfTeams = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hackathons", x => x.HackathonID);
                });

            migrationBuilder.CreateTable(
                name: "HackathonChallenges",
                columns: table => new
                {
                    HackathonID = table.Column<int>(type: "int", nullable: false),
                    ChallengeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HackathonChallenges", x => new { x.HackathonID, x.ChallengeID });
                    table.ForeignKey(
                        name: "FK_HackathonChallenges_Challenges_ChallengeID",
                        column: x => x.ChallengeID,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HackathonChallenges_Hackathons_HackathonID",
                        column: x => x.HackathonID,
                        principalTable: "Hackathons",
                        principalColumn: "HackathonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HackathonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Hackathons_HackathonID",
                        column: x => x.HackathonID,
                        principalTable: "Hackathons",
                        principalColumn: "HackathonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamChallenges",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    ChallengeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChallenges", x => new { x.TeamID, x.ChallengeID });
                    table.ForeignKey(
                        name: "FK_TeamChallenges_Challenges_ChallengeID",
                        column: x => x.ChallengeID,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamChallenges_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: true),
                    CompetitorID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HackathonChallenges_ChallengeID",
                table: "HackathonChallenges",
                column: "ChallengeID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallenges_ChallengeID",
                table: "TeamChallenges",
                column: "ChallengeID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HackathonID",
                table: "Teams",
                column: "HackathonID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamID",
                table: "Users",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HackathonChallenges");

            migrationBuilder.DropTable(
                name: "TeamChallenges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Hackathons");
        }
    }
}
