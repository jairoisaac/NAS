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
    public class ComisionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comisions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comisions.ToListAsync());
        }

        // GET: Comisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comision = await _context.Comisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comision == null)
            {
                return NotFound();
            }

            return View(comision);
        }

        // GET: Comisions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comision);
        }

        // GET: Comisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comision = await _context.Comisions.FindAsync(id);
            if (comision == null)
            {
                return NotFound();
            }
            return View(comision);
        }

        // POST: Comisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] Comision comision)
        {
            if (id != comision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComisionExists(comision.Id))
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
            return View(comision);
        }

        // GET: Comisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comision = await _context.Comisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comision == null)
            {
                return NotFound();
            }

            return View(comision);
        }

        // POST: Comisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comision = await _context.Comisions.FindAsync(id);
            _context.Comisions.Remove(comision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComisionExists(int id)
        {
            return _context.Comisions.Any(e => e.Id == id);
        }
    }
}
