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
    public class BasicCostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasicCostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BasicCosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BasicCosts.ToListAsync());
        }

        // GET: BasicCosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicCost = await _context.BasicCosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basicCost == null)
            {
                return NotFound();
            }

            return View(basicCost);
        }

        // GET: BasicCosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BasicCosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] BasicCost basicCost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basicCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basicCost);
        }

        // GET: BasicCosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicCost = await _context.BasicCosts.FindAsync(id);
            if (basicCost == null)
            {
                return NotFound();
            }
            return View(basicCost);
        }

        // POST: BasicCosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] BasicCost basicCost)
        {
            if (id != basicCost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicCostExists(basicCost.Id))
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
            return View(basicCost);
        }

        // GET: BasicCosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicCost = await _context.BasicCosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basicCost == null)
            {
                return NotFound();
            }

            return View(basicCost);
        }

        // POST: BasicCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicCost = await _context.BasicCosts.FindAsync(id);
            _context.BasicCosts.Remove(basicCost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicCostExists(int id)
        {
            return _context.BasicCosts.Any(e => e.Id == id);
        }
    }
}
