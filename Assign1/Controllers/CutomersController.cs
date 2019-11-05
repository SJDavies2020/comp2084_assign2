using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assign1.Models;

namespace Assign1.Controllers
{
    public class CutomersController : Controller
    {
        private readonly Assign1Context _context;

        public CutomersController(Assign1Context context)
        {
            _context = context;
        }

        // GET: Cutomers
        public async Task<IActionResult> Index()
        {
            var assign1Context = _context.Cutomers.Include(c => c.CarMake).Include(c => c.CarModel).Include(c => c.Prov).Include(c => c.Warrenty);
            return View(await assign1Context.ToListAsync());
        }

        // GET: Cutomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cutomers = await _context.Cutomers
                .Include(c => c.CarMake)
                .Include(c => c.CarModel)
                .Include(c => c.Prov)
                .Include(c => c.Warrenty)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (cutomers == null)
            {
                return NotFound();
            }

            return View(cutomers);
        }

        // GET: Cutomers/Create
        public IActionResult Create()
        {
            ViewData["CarMakeId"] = new SelectList(_context.Cmake, "CmakeId", "CarMake");
            ViewData["CarModelId"] = new SelectList(_context.Cmodel, "CarModelId", "CarModel");
            ViewData["ProvId"] = new SelectList(_context.Province, "ProvinceId", "Province1");
            ViewData["WarrentyId"] = new SelectList(_context.Warrenty, "WarrentyId", "WarrentyId");
            return View();
        }

        // POST: Cutomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Name,Address,City,PostalCode,ProvId,WarrentyId,CarMakeId,CarModelId,CarYear,VIN")] Cutomers cutomers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cutomers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarMakeId"] = new SelectList(_context.Cmake, "CmakeId", "CarMake", cutomers.CarMakeId);
            ViewData["CarModelId"] = new SelectList(_context.Cmodel, "CarModelId", "CarModel", cutomers.CarModelId);
            ViewData["ProvId"] = new SelectList(_context.Province, "ProvinceId", "Province1", cutomers.ProvId);
            ViewData["WarrentyId"] = new SelectList(_context.Warrenty, "WarrentyId", "WarrentyId", cutomers.WarrentyId);
            return View(cutomers);
        }

        // GET: Cutomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cutomers = await _context.Cutomers.FindAsync(id);
            if (cutomers == null)
            {
                return NotFound();
            }
            ViewData["CarMakeId"] = new SelectList(_context.Cmake, "CmakeId", "CarMake", cutomers.CarMakeId);
            ViewData["CarModelId"] = new SelectList(_context.Cmodel, "CarModelId", "CarModel", cutomers.CarModelId);
            ViewData["ProvId"] = new SelectList(_context.Province, "ProvinceId", "Province1", cutomers.ProvId);
            ViewData["WarrentyId"] = new SelectList(_context.Warrenty, "WarrentyId", "WarrentyId", cutomers.WarrentyId);
            return View(cutomers);
        }

        // POST: Cutomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Name,Address,City,PostalCode,ProvId,WarrentyId,CarMakeId,CarModelId,CarYear,VIN")] Cutomers cutomers)
        {
            if (id != cutomers.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cutomers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CutomersExists(cutomers.CustomerId))
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
            ViewData["CarMakeId"] = new SelectList(_context.Cmake, "CmakeId", "CarMake", cutomers.CarMakeId);
            ViewData["CarModelId"] = new SelectList(_context.Cmodel, "CarModelId", "CarModel", cutomers.CarModelId);
            ViewData["ProvId"] = new SelectList(_context.Province, "ProvinceId", "Province1", cutomers.ProvId);
            ViewData["WarrentyId"] = new SelectList(_context.Warrenty, "WarrentyId", "WarrentyId", cutomers.WarrentyId);
            return View(cutomers);
        }

        // GET: Cutomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cutomers = await _context.Cutomers
                .Include(c => c.CarMake)
                .Include(c => c.CarModel)
                .Include(c => c.Prov)
                .Include(c => c.Warrenty)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (cutomers == null)
            {
                return NotFound();
            }

            return View(cutomers);
        }

        // POST: Cutomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cutomers = await _context.Cutomers.FindAsync(id);
            _context.Cutomers.Remove(cutomers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CutomersExists(int id)
        {
            return _context.Cutomers.Any(e => e.CustomerId == id);
        }
    }
}
