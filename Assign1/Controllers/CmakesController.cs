using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assign1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assign1.Controllers

{
    [Authorize]
    public class CmakesController : Controller
    {
        private readonly Assign1Context _context;

        public CmakesController(Assign1Context context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Cmakes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cmake.ToListAsync());
        }
        [AllowAnonymous]
        // GET: Cmakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmake = await _context.Cmake
                .FirstOrDefaultAsync(m => m.CmakeId == id);
            if (cmake == null)
            {
                return NotFound();
            }

            return View(cmake);
        }

        
        // GET: Cmakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cmakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CmakeId,CarMake")] Cmake cmake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmake);
        }

       
        // GET: Cmakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmake = await _context.Cmake.FindAsync(id);
            if (cmake == null)
            {
                return NotFound();
            }
            return View(cmake);
        }

        // POST: Cmakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CmakeId,CarMake")] Cmake cmake)
        {
            if (id != cmake.CmakeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmakeExists(cmake.CmakeId))
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
            return View(cmake);
        }
      
        // GET: Cmakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmake = await _context.Cmake
                .FirstOrDefaultAsync(m => m.CmakeId == id);
            if (cmake == null)
            {
                return NotFound();
            }

            return View(cmake);
        }

        // POST: Cmakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cmake = await _context.Cmake.FindAsync(id);
            _context.Cmake.Remove(cmake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CmakeExists(int id)
        {
            return _context.Cmake.Any(e => e.CmakeId == id);
        }
    }
}
