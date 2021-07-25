using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NAS.Data;
using NAS.Data.Entities;

namespace NAS.Controllers
{
    public class NAS_EmptyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NAS_EmptyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NAS_Empty
        public async Task<IActionResult> Index()
        {
            return View(await _context.NASEmptys.ToListAsync());
        }

        // GET: NAS_Empty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nAS_Empty = await _context.NASEmptys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nAS_Empty == null)
            {
                return NotFound();
            }

            return View(nAS_Empty);
        }

        // GET: NAS_Empty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NAS_Empty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Manufacturer,SKU,Description,Cost")] NAS_Empty nAS_Empty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nAS_Empty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nAS_Empty);
        }

        // GET: NAS_Empty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nAS_Empty = await _context.NASEmptys.FindAsync(id);
            if (nAS_Empty == null)
            {
                return NotFound();
            }
            return View(nAS_Empty);
        }

        // POST: NAS_Empty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Manufacturer,SKU,Description,Cost")] NAS_Empty nAS_Empty)
        {
            if (id != nAS_Empty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nAS_Empty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NAS_EmptyExists(nAS_Empty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nAS_Empty);
        }

        // GET: NAS_Empty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nAS_Empty = await _context.NASEmptys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nAS_Empty == null)
            {
                return NotFound();
            }

            return View(nAS_Empty);
        }

        // POST: NAS_Empty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nAS_Empty = await _context.NASEmptys.FindAsync(id);
            _context.NASEmptys.Remove(nAS_Empty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NAS_EmptyExists(int id)
        {
            return _context.NASEmptys.Any(e => e.Id == id);
        }
    }
}
