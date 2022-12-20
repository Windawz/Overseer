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
    public class RedemptionAttemptsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RedemptionAttemptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RedemptionAttempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RedemptionAttempt>>> GetRedemptionAttempts()
        {
            return await _context.RedemptionAttempts.ToListAsync();
        }

        // GET: api/RedemptionAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RedemptionAttempt>> GetRedemptionAttempt(int id)
        {
            var redemptionAttempt = await _context.RedemptionAttempts.FindAsync(id);

            if (redemptionAttempt == null)
            {
                return NotFound();
            }

            return redemptionAttempt;
        }

        // PUT: api/RedemptionAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedemptionAttempt(int id, RedemptionAttempt redemptionAttempt)
        {
            if (id != redemptionAttempt.Id)
            {
                return BadRequest();
            }

            _context.Entry(redemptionAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedemptionAttemptExists(id))
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

        // POST: api/RedemptionAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RedemptionAttempt>> PostRedemptionAttempt(RedemptionAttempt redemptionAttempt)
        {
            _context.RedemptionAttempts.Add(redemptionAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRedemptionAttempt", new { id = redemptionAttempt.Id }, redemptionAttempt);
        }

        // DELETE: api/RedemptionAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedemptionAttempt(int id)
        {
            var redemptionAttempt = await _context.RedemptionAttempts.FindAsync(id);
            if (redemptionAttempt == null)
            {
                return NotFound();
            }

            _context.RedemptionAttempts.Remove(redemptionAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RedemptionAttemptExists(int id)
        {
            return _context.RedemptionAttempts.Any(e => e.Id == id);
        }
    }
}
