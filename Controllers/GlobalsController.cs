using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using expense_tracker;
using expense_tracker.Models;

namespace expense_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GlobalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Globals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Global>>> GetGlobal()
        {
            return await _context.Global.ToListAsync();
        }

        // GET: api/Globals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Global>> GetGlobal(int id)
        {
            var @global = await _context.Global.FindAsync(id);

            if (@global == null)
            {
                return NotFound();
            }

            return @global;
        }

        // PUT: api/Globals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlobal(int id, Global @global)
        {
            if (id != @global.Id)
            {
                return BadRequest();
            }

            _context.Entry(@global).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlobalExists(id))
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

        // POST: api/Globals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Global>> PostGlobal(Global @global)
        {
            _context.Global.Add(@global);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGlobal", new { id = @global.Id }, @global);
        }

        // DELETE: api/Globals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlobal(int id)
        {
            var @global = await _context.Global.FindAsync(id);
            if (@global == null)
            {
                return NotFound();
            }

            _context.Global.Remove(@global);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GlobalExists(int id)
        {
            return _context.Global.Any(e => e.Id == id);
        }
    }
}
