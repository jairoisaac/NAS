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
    public class BasicCostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BasicCostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BasicCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicCost>>> GetBasicCosts()
        {
            return await _context.BasicCosts.ToListAsync();
        }

        // GET: api/BasicCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicCost>> GetBasicCost(int id)
        {
            var basicCost = await _context.BasicCosts.FindAsync(id);

            if (basicCost == null)
            {
                return NotFound();
            }

            return basicCost;
        }

        // PUT: api/BasicCosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicCost(int id, BasicCost basicCost)
        {
            if (id != basicCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(basicCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicCostExists(id))
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

        // POST: api/BasicCosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BasicCost>> PostBasicCost(BasicCost basicCost)
        {
            _context.BasicCosts.Add(basicCost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicCost", new { id = basicCost.Id }, basicCost);
        }

        // DELETE: api/BasicCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BasicCost>> DeleteBasicCost(int id)
        {
            var basicCost = await _context.BasicCosts.FindAsync(id);
            if (basicCost == null)
            {
                return NotFound();
            }

            _context.BasicCosts.Remove(basicCost);
            await _context.SaveChangesAsync();

            return basicCost;
        }

        private bool BasicCostExists(int id)
        {
            return _context.BasicCosts.Any(e => e.Id == id);
        }
    }
}
