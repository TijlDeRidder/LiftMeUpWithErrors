using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiftMeUp2.Data;
using LiftMeUp2.Models;

namespace LiftMeUp2.Controllers
{
    public class MeldingsController : Controller
    {
        private readonly LiftMeUp2Context _context;

        public MeldingsController(LiftMeUp2Context context)
        {
            _context = context;
        }

        // GET: Meldings
        public async Task<IActionResult> Index()
        {
              return View(await _context.Melding.ToListAsync());
        }

        // GET: Meldings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Melding == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding
                .FirstOrDefaultAsync(m => m.MeldingId == id);
            if (melding == null)
            {
                return NotFound();
            }

            return View(melding);
        }

        // GET: Meldings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meldings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeldingId,liftId,stationId,startDate,isDeleted")] Melding melding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(melding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(melding);
        }

        // GET: Meldings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Melding == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding.FindAsync(id);
            if (melding == null)
            {
                return NotFound();
            }
            return View(melding);
        }

        // POST: Meldings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeldingId,liftId,stationId,startDate,isDeleted")] Melding melding)
        {
            if (id != melding.MeldingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeldingExists(melding.MeldingId))
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
            return View(melding);
        }

        // GET: Meldings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Melding == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding
                .FirstOrDefaultAsync(m => m.MeldingId == id);
            if (melding == null)
            {
                return NotFound();
            }

            return View(melding);
        }

        // POST: Meldings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Melding == null)
            {
                return Problem("Entity set 'LiftMeUp2Context.Melding'  is null.");
            }
            var melding = await _context.Melding.FindAsync(id);
            if (melding != null)
            {
                melding.isDeleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeldingExists(int id)
        {
          return _context.Melding.Any(e => e.MeldingId == id);
        }
    }
}
