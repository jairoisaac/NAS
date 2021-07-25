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
    public class HardDrivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HardDrivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HardDrives
        public async Task<IActionResult> Index()
        {
            return View(await _context.HardDrives.ToListAsync());
        }

        // GET: HardDrives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardDrive = await _context.HardDrives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardDrive == null)
            {
                return NotFound();
            }

            return View(hardDrive);
        }

        // GET: HardDrives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HardDrives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Manufacturer,SKU,Description,Cost")] HardDrive hardDrive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardDrive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardDrive);
        }

        // GET: HardDrives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardDrive = await _context.HardDrives.FindAsync(id);
            if (hardDrive == null)
            {
                return NotFound();
            }
            return View(hardDrive);
        }

        // POST: HardDrives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Manufacturer,SKU,Description,Cost")] HardDrive hardDrive)
        {
            if (id != hardDrive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardDrive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardDriveExists(hardDrive.Id))
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
            return View(hardDrive);
        }

        // GET: HardDrives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardDrive = await _context.HardDrives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardDrive == null)
            {
                return NotFound();
            }

            return View(hardDrive);
        }

        // POST: HardDrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardDrive = await _context.HardDrives.FindAsync(id);
            _context.HardDrives.Remove(hardDrive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardDriveExists(int id)
        {
            return _context.HardDrives.Any(e => e.Id == id);
        }
    }
}
