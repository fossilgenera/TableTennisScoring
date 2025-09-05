using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableTennisScoring.Models;

namespace TableTennisScoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        private readonly TableTennisScoringContext _context;

        public RulesController(TableTennisScoringContext context)
        {
            _context = context;
        }

        // GET: api/Rules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rule>>> GetGameTypeRules()
        {
            return await _context.GameTypeRules.ToListAsync();
        }

        // GET: api/Rules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rule>> GetRule(int id)
        {
            var rule = await _context.GameTypeRules.FindAsync(id);

            if (rule == null)
            {
                return NotFound();
            }

            return rule;
        }

        // PUT: api/Rules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRule(int id, Rule rule)
        {
            if (id != rule.RuleId)
            {
                return BadRequest();
            }

            _context.Entry(rule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuleExists(id))
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

        // POST: api/Rules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rule>> PostRule(Rule rule)
        {
            _context.GameTypeRules.Add(rule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRule", new { id = rule.RuleId }, rule);
        }

        // DELETE: api/Rules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            var rule = await _context.GameTypeRules.FindAsync(id);
            if (rule == null)
            {
                return NotFound();
            }

            _context.GameTypeRules.Remove(rule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RuleExists(int id)
        {
            return _context.GameTypeRules.Any(e => e.RuleId == id);
        }
    }
}
