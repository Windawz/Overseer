using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Overseer.Backend;
using Overseer.Data;

namespace Overseer.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedemptionConclusionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RedemptionConclusionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RedemptionConclusions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RedemptionConclusion>>> GetRedemptionConclusions()
        {
            return await _context.RedemptionConclusions.ToListAsync();
        }

        // GET: api/RedemptionConclusions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RedemptionConclusion>> GetRedemptionConclusion(int id)
        {
            var redemptionConclusion = await _context.RedemptionConclusions.FindAsync(id);

            if (redemptionConclusion == null)
            {
                return NotFound();
            }

            return redemptionConclusion;
        }

        // PUT: api/RedemptionConclusions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedemptionConclusion(int id, RedemptionConclusion redemptionConclusion)
        {
            if (id != redemptionConclusion.Id)
            {
                return BadRequest();
            }

            _context.Entry(redemptionConclusion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedemptionConclusionExists(id))
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

        // POST: api/RedemptionConclusions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RedemptionConclusion>> PostRedemptionConclusion(RedemptionConclusion redemptionConclusion)
        {
            _context.RedemptionConclusions.Add(redemptionConclusion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRedemptionConclusion", new { id = redemptionConclusion.Id }, redemptionConclusion);
        }

        // DELETE: api/RedemptionConclusions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedemptionConclusion(int id)
        {
            var redemptionConclusion = await _context.RedemptionConclusions.FindAsync(id);
            if (redemptionConclusion == null)
            {
                return NotFound();
            }

            _context.RedemptionConclusions.Remove(redemptionConclusion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RedemptionConclusionExists(int id)
        {
            return _context.RedemptionConclusions.Any(e => e.Id == id);
        }
    }
}
