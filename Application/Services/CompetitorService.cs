using Microsoft.EntityFrameworkCore;
using TableTennisScoring.Application.Commands;
using TableTennisScoring.Application.Lookups;
using TableTennisScoring.Models;
using TableTennisScoring.Models.Base;

namespace TableTennisScoring.Application.Services
{
    /// <summary>
    /// Competitor service for managing competitor-related operations.
    /// </summary>
    public class CompetitorService
    {
        private readonly TableTennisScoringContext context;

        /// <summary>
        /// Competitor service constructor.
        /// </summary>
        /// <param name="context">DB Context.</param>
        public CompetitorService(
            TableTennisScoringContext context)
        {
            this.context = context;
        }

        public async Task<List<CompetitorLookup>> GetCompetitorsBySearchCriteriaAsync(string? searchCriteria)
        {
            var searchString = searchCriteria?.Trim().ToLower() ?? string.Empty;
            return await this.context.Competitors
                .Where(c => c.CompetitorFirstName.ToLower().Contains(searchString) ||
                            c.CompetitorLastName.ToLower().Contains(searchString) ||
                            c.CompetitorNickname.ToLower().Contains(searchString))
                .Select(c => new CompetitorLookup
                {
                    CompetitorFullName = $"{c.CompetitorFirstName} {c.CompetitorLastName}",
                    CompetitorNickname = c.CompetitorNickname,
                    CompetitorId = c.CompetitorId,
                    NumberOfMatchesPlayed = c.MatchCompetitors.Where(mc => mc.CompetitorId == c.CompetitorId).Count(),
                    NumberOfWins = c.MatchCompetitors.Where(mc => mc.CompetitorId == c.CompetitorId && mc.IsWinner).Count()
                })
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Create new competitor asynchronously.
        /// </summary>
        /// <param name="createCompetitorCommand">Create competitor command.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateCompetitorAsync(CreateCompetitorCommand createCompetitorCommand)
        {
            try
            {
                bool competitorExists = await this.CompetitorExists(createCompetitorCommand.CompetitorFirstName, createCompetitorCommand.CompetitorLastName).ConfigureAwait(false);

                if (competitorExists)
                {
                    throw new Exception("Competitor with the same first and last name already exists.");
                }
                var competitor = new Competitor
                {
                    CompetitorFirstName = createCompetitorCommand.CompetitorFirstName,
                    CompetitorLastName = createCompetitorCommand.CompetitorLastName,
                    CompetitorNickname = createCompetitorCommand.CompetitorNickname ?? string.Empty
                };
                await this.context.Competitors.AddAsync(competitor).ConfigureAwait(false);
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't create competitor: {ex}");
            }
        }

        private async Task<bool> CompetitorExists(string firstName, string lastName)
        {
            return await this.context.Competitors.AnyAsync(c => c.CompetitorFirstName == firstName && c.CompetitorLastName == lastName).ConfigureAwait(false);
        }
    }
}
