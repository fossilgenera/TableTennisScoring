using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableTennisScoring.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchCompetitor_Competitors_CompetitorId",
                table: "MatchCompetitor");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchCompetitor_Matches_MatchId",
                table: "MatchCompetitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchCompetitor",
                table: "MatchCompetitor");

            migrationBuilder.RenameTable(
                name: "MatchCompetitor",
                newName: "MatchCompetitors");

            migrationBuilder.RenameIndex(
                name: "IX_MatchCompetitor_MatchId",
                table: "MatchCompetitors",
                newName: "IX_MatchCompetitors_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchCompetitor_CompetitorId",
                table: "MatchCompetitors",
                newName: "IX_MatchCompetitors_CompetitorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchCompetitors",
                table: "MatchCompetitors",
                column: "MatchCompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchCompetitors_Competitors_CompetitorId",
                table: "MatchCompetitors",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "CompetitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchCompetitors_Matches_MatchId",
                table: "MatchCompetitors",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchCompetitors_Competitors_CompetitorId",
                table: "MatchCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchCompetitors_Matches_MatchId",
                table: "MatchCompetitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchCompetitors",
                table: "MatchCompetitors");

            migrationBuilder.RenameTable(
                name: "MatchCompetitors",
                newName: "MatchCompetitor");

            migrationBuilder.RenameIndex(
                name: "IX_MatchCompetitors_MatchId",
                table: "MatchCompetitor",
                newName: "IX_MatchCompetitor_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchCompetitors_CompetitorId",
                table: "MatchCompetitor",
                newName: "IX_MatchCompetitor_CompetitorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchCompetitor",
                table: "MatchCompetitor",
                column: "MatchCompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchCompetitor_Competitors_CompetitorId",
                table: "MatchCompetitor",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "CompetitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchCompetitor_Matches_MatchId",
                table: "MatchCompetitor",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
