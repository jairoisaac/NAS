using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NAS.Data;
using NAS.Data.Entities;
using NAS.ViewModels;

namespace NAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NAS_EmptyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly ILogger<NAS_EmptyController> _logger;


        public NAS_EmptyController(ApplicationDbContext context,IMapper mapper, ILogger<NAS_EmptyController> logger)
        {
            _logger = logger;
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/NAS_Empty
        //[HttpGet]

        //public async Task<ActionResult<IEnumerable<NAS_Empty>>> GetNASEmptys()
        //{
        //    return await _context.NASEmptys.ToListAsync();
        //}
        // GET: api/NAS_Empty
        [HttpGet]

        public async Task<ActionResult<IEnumerable<NAS_Price>>> GetNASEmptys()
        {
            //var result = 
            //return await _context.NASEmptys.ToListAsync();
            return await _context.NASEmptys.Select(n => new NAS_Price { Cost = n.Cost, Id = n.Id, SKU = n.SKU }).ToListAsync();
        }

        // GET: api/NAS_Empty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NAS_Empty>> GetNAS_Empty(int id)
        {
            var nAS_Empty = await _context.NASEmptys.FindAsync(id);

            if (nAS_Empty == null)
            {
                return NotFound();
            }

            return nAS_Empty;
        }

        // PUT: api/NAS_Empty/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNAS_Empty(int id, NAS_Empty nAS_Empty)
        {
            if (id != nAS_Empty.Id)
            {
                return BadRequest();
            }

            _context.Entry(nAS_Empty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NAS_EmptyExists(id))
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

        // POST: api/NAS_Empty
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NAS_Empty>> PostNAS_Empty(NAS_Empty nAS_Empty)
        {
            _context.NASEmptys.Add(nAS_Empty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNAS_Empty", new { id = nAS_Empty.Id }, nAS_Empty);
        }

        // DELETE: api/NAS_Empty/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NAS_Empty>> DeleteNAS_Empty(int id)
        {
            var nAS_Empty = await _context.NASEmptys.FindAsync(id);
            if (nAS_Empty == null)
            {
                return NotFound();
            }

            _context.NASEmptys.Remove(nAS_Empty);
            await _context.SaveChangesAsync();

            return nAS_Empty;
        }

        private bool NAS_EmptyExists(int id)
        {
            return _context.NASEmptys.Any(e => e.Id == id);
        }
    }
}
