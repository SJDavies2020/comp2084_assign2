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
    public class WarrentiesController : Controller
    {
        private readonly Assign1Context _context;

        public WarrentiesController(Assign1Context context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Warrenties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Warrenty.ToListAsync());
        }
        [AllowAnonymous]
        // GET: Warrenties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warrenty = await _context.Warrenty
                .FirstOrDefaultAsync(m => m.WarrentyId == id);
            if (warrenty == null)
            {
                return NotFound();
            }

            return View(warrenty);
        }
       
        // GET: Warrenties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Warrenties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WarrentyId,WarrentyTerm")] Warrenty warrenty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warrenty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warrenty);
        }
        
        // GET: Warrenties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warrenty = await _context.Warrenty.FindAsync(id);
            if (warrenty == null)
            {
                return NotFound();
            }
            return View(warrenty);
        }

        // POST: Warrenties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WarrentyId,WarrentyTerm")] Warrenty warrenty)
        {
            if (id != warrenty.WarrentyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warrenty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarrentyExists(warrenty.WarrentyId))
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
            return View(warrenty);
        }
        
        // GET: Warrenties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warrenty = await _context.Warrenty
                .FirstOrDefaultAsync(m => m.WarrentyId == id);
            if (warrenty == null)
            {
                return NotFound();
            }

            return View(warrenty);
        }

        // POST: Warrenties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warrenty = await _context.Warrenty.FindAsync(id);
            _context.Warrenty.Remove(warrenty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarrentyExists(int id)
        {
            return _context.Warrenty.Any(e => e.WarrentyId == id);
        }
    }
}
