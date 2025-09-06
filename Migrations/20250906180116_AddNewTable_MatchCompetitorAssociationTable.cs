using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableTennisScoring.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTable_MatchCompetitorAssociationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Competitors_CompetitorId1",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Competitors_CompetitorId2",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Competitors_CompetitorId3",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Competitors_CompetitorId4",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CompetitorId1",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CompetitorId2",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CompetitorId3",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CompetitorId4",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId1",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId1FinalScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId2",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId2FinalScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId3",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId3FinalScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId4",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitorId4FinalScore",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "MatchCompetitor",
                columns: table => new
                {
                    MatchCompetitorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", maxLength: 2, nullable: false),
                    IsWinner = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchCompetitor", x => x.MatchCompetitorId);
                    table.ForeignKey(
                        name: "FK_MatchCompetitor_Competitors_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchCompetitor_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchCompetitor_CompetitorId",
                table: "MatchCompetitor",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchCompetitor_MatchId",
                table: "MatchCompetitor",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchCompetitor");

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId1",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId1FinalScore",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId2",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId2FinalScore",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId3",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId3FinalScore",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId4",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId4FinalScore",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_CompetitorId1",
                table: "Matches",
                column: "CompetitorId1",
                principalTable: "Competitors",
                principalColumn: "CompetitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_CompetitorId2",
                table: "Matches",
                column: "CompetitorId2",
                principalTable: "Competitors",
                principalColumn: "CompetitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_CompetitorId3",
                table: "Matches",
                column: "CompetitorId3",
                principalTable: "Competitors",
                principalColumn: "CompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_CompetitorId4",
                table: "Matches",
                column: "CompetitorId4",
                principalTable: "Competitors",
                principalColumn: "CompetitorId");
        }
    }
}
