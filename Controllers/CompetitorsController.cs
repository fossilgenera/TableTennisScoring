using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableTennisScoring.Application.Commands;
using TableTennisScoring.Application.Services;
using TableTennisScoring.Models;
using TableTennisScoring.Models.Base;

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
        public async Task<ActionResult<IEnumerable<Competitor>>> GetCompetitors()
        {
            return await context.Competitors.ToListAsync();
        }

        // GET: api/Competitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competitor>> GetCompetitor(int id)
        {
            var competitor = await context.Competitors.FindAsync(id);

            if (competitor == null)
            {
                return NotFound();
            }

            return competitor;
        }

        // PUT: api/Competitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitor(int id, Competitor competitor)
        {
            if (id != competitor.CompetitorId)
            {
                return BadRequest();
            }

            context.Entry(competitor).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> CreateCompetitor(CreateCompetitorCommand createCompetitorCommand)
        {
            await this.competitorService.CreateCompetitorAsync(createCompetitorCommand).ConfigureAwait(false);
            return this.Ok();

        }

        // DELETE: api/Competitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }

            context.Competitors.Remove(competitor);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitorExists(int id)
        {
            return context.Competitors.Any(e => e.CompetitorId == id);
        }
    }
}
