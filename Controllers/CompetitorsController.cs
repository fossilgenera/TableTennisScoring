using Microsoft.AspNetCore.Mvc;
using TableTennisScoring.Application.Commands;
using TableTennisScoring.Application.Lookups;
using TableTennisScoring.Application.Services;
using TableTennisScoring.Models;

namespace TableTennisScoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly TableTennisScoringContext context;
        private readonly CompetitorService competitorService;

        public CompetitorsController(TableTennisScoringContext context)
        {
            this.context = context;
            this.competitorService = new CompetitorService(context);
        }

        // GET: api/Competitors
        [HttpGet]
        public async Task<ActionResult<List<CompetitorLookup>>> GetCompetitorsBySearchCriteria(string? searchCriteria)
        {
            return await this.competitorService.GetCompetitorsBySearchCriteriaAsync(searchCriteria).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompetitor(CreateCompetitorCommand createCompetitorCommand)
        {
            await this.competitorService.CreateCompetitorAsync(createCompetitorCommand).ConfigureAwait(false);
            return this.Ok();

        }
    }
}
