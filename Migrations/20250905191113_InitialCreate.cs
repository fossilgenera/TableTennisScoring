using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTennisScoring.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    CompetitorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetitorFirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CompetitorLastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CompetitorNickname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.CompetitorId);
                });

            migrationBuilder.CreateTable(
                name: "GameTypeRules",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RuleDescription = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypeRules", x => x.RuleId);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetitorId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorId3 = table.Column<int>(type: "INTEGER", nullable: true),
                    CompetitorId4 = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompetitorId1FinalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorId2FinalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorId3FinalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorId4FinalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    BestOfAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Competitors_CompetitorId1",
                        column: x => x.CompetitorId1,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Competitors_CompetitorId2",
                        column: x => x.CompetitorId2,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Competitors_CompetitorId3",
                        column: x => x.CompetitorId3,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId");
                    table.ForeignKey(
                        name: "FK_Matches_Competitors_CompetitorId4",
                        column: x => x.CompetitorId4,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId");
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "CompetitorId", "CompetitorFirstName", "CompetitorLastName", "CompetitorNickname" },
                values: new object[,]
                {
                    { 1, "Monique", "Springer", "Monik" },
                    { 2, "Bob", "Jones", "Smash" },
                    { 3, "Alice", "Smith", "Ace" }
                });

            migrationBuilder.InsertData(
                table: "GameTypeRules",
                columns: new[] { "RuleId", "RuleDescription", "RuleName" },
                values: new object[,]
                {
                    { 1, "The goal is to score points by hitting the ball over the net so that the opponent cannot return it legally.", "Game Objective" },
                    { 2, "Games are typically played to 11 points, and a player must win by at least a 2-point margin.", "Scoring System" },
                    { 3, "The serve must be made from behind the end line and the ball must bounce once on the server's side before crossing the net.", "Service Rules" },
                    { 4, "In singles, players alternate serves every 2 points. In doubles, each player serves for 2 points in a fixed rotation.", "Serve Rotation" },
                    { 5, "After the serve, the ball must be hit over the net and bounce once on the opponent's side. It cannot bounce more than once on your own side.", "Legal Return" },
                    { 6, "A rally continues until a player fails to make a legal return, hits the ball off the table without touching the opponent's side, or commits a fault.", "Ball In Play" },
                    { 7, "A let is called when the serve touches the net but still lands in the correct service box. The serve is retaken without penalty.", "Let" },
                    { 8, "If the ball touches the net during a rally but still lands on the opponent's side, play continues.", "Ball Touching the Net During Play" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitorId1",
                table: "Matches",
                column: "CompetitorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitorId2",
                table: "Matches",
                column: "CompetitorId2");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitorId3",
                table: "Matches",
                column: "CompetitorId3");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitorId4",
                table: "Matches",
                column: "CompetitorId4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTypeRules");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Competitors");
        }
    }
}
