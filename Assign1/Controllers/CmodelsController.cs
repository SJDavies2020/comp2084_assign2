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
    public class CmodelsController : Controller
    {
        private readonly Assign1Context _context;

        public CmodelsController(Assign1Context context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Cmodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cmodel.ToListAsync());
        }
        [AllowAnonymous]
        // GET: Cmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmodel = await _context.Cmodel
                .FirstOrDefaultAsync(m => m.CarModelId == id);
            if (cmodel == null)
            {
                return NotFound();
            }

            return View(cmodel);
        }
        
        // GET: Cmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarModelId,CarModel")] Cmodel cmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmodel);
        }
       
        // GET: Cmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmodel = await _context.Cmodel.FindAsync(id);
            if (cmodel == null)
            {
                return NotFound();
            }
            return View(cmodel);
        }

        // POST: Cmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarModelId,CarModel")] Cmodel cmodel)
        {
            if (id != cmodel.CarModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmodelExists(cmodel.CarModelId))
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
            return View(cmodel);
        }
      
        // GET: Cmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmodel = await _context.Cmodel
                .FirstOrDefaultAsync(m => m.CarModelId == id);
            if (cmodel == null)
            {
                return NotFound();
            }

            return View(cmodel);
        }

        // POST: Cmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cmodel = await _context.Cmodel.FindAsync(id);
            _context.Cmodel.Remove(cmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CmodelExists(int id)
        {
            return _context.Cmodel.Any(e => e.CarModelId == id);
        }
    }
}
