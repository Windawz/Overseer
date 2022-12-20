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
    public class ServiceKindsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceKindsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceKinds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceKind>>> GetServiceKinds()
        {
            return await _context.ServiceKinds.ToListAsync();
        }

        // GET: api/ServiceKinds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceKind>> GetServiceKind(int id)
        {
            var serviceKind = await _context.ServiceKinds.FindAsync(id);

            if (serviceKind == null)
            {
                return NotFound();
            }

            return serviceKind;
        }

        // PUT: api/ServiceKinds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceKind(int id, ServiceKind serviceKind)
        {
            if (id != serviceKind.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceKind).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceKindExists(id))
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

        // POST: api/ServiceKinds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceKind>> PostServiceKind(ServiceKind serviceKind)
        {
            _context.ServiceKinds.Add(serviceKind);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceKind", new { id = serviceKind.Id }, serviceKind);
        }

        // DELETE: api/ServiceKinds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceKind(int id)
        {
            var serviceKind = await _context.ServiceKinds.FindAsync(id);
            if (serviceKind == null)
            {
                return NotFound();
            }

            _context.ServiceKinds.Remove(serviceKind);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceKindExists(int id)
        {
            return _context.ServiceKinds.Any(e => e.Id == id);
        }
    }
}
