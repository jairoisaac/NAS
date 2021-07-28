using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAS.Data;
using NAS.Data.Entities;

namespace NAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComisionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comision>>> GetComisions()
        {
            return await _context.Comisions.ToListAsync();
        }

        // GET: api/Comisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comision>> GetComision(int id)
        {
            var comision = await _context.Comisions.FindAsync(id);

            if (comision == null)
            {
                return NotFound();
            }

            return comision;
        }

        // PUT: api/Comisions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComision(int id, Comision comision)
        {
            if (id != comision.Id)
            {
                return BadRequest();
            }

            _context.Entry(comision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComisionExists(id))
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

        // POST: api/Comisions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comision>> PostComision(Comision comision)
        {
            _context.Comisions.Add(comision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComision", new { id = comision.Id }, comision);
        }

        // DELETE: api/Comisions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comision>> DeleteComision(int id)
        {
            var comision = await _context.Comisions.FindAsync(id);
            if (comision == null)
            {
                return NotFound();
            }

            _context.Comisions.Remove(comision);
            await _context.SaveChangesAsync();

            return comision;
        }

        private bool ComisionExists(int id)
        {
            return _context.Comisions.Any(e => e.Id == id);
        }
    }
}
