using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zames.Data;
using zames.Models;

namespace zames.Controllers
{
    public class ZamestnanecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZamestnanecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zamestnanecs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zamestnanec.ToListAsync());
        }

        // GET: Zamestnanecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamestnanec = await _context.Zamestnanec
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zamestnanec == null)
            {
                return NotFound();
            }

            return View(zamestnanec);
        }

        // GET: Zamestnanecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zamestnanecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Meno,Priezvisko,Január,Február,Marec,Apríl,Máj,Jún,Júl,August,September,Október,November,December")] Zamestnanec zamestnanec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamestnanec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zamestnanec);
        }

        // GET: Zamestnanecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamestnanec = await _context.Zamestnanec.FindAsync(id);
            if (zamestnanec == null)
            {
                return NotFound();
            }
            return View(zamestnanec);
        }

        // POST: Zamestnanecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Meno,Priezvisko,Január,Február,Marec,Apríl,Máj,Jún,Júl,August,September,Október,November,December")] Zamestnanec zamestnanec)
        {
            if (id != zamestnanec.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamestnanec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamestnanecExists(zamestnanec.ID))
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
            return View(zamestnanec);
        }

        // GET: Zamestnanecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamestnanec = await _context.Zamestnanec
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zamestnanec == null)
            {
                return NotFound();
            }

            return View(zamestnanec);
        }

        // POST: Zamestnanecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamestnanec = await _context.Zamestnanec.FindAsync(id);
            _context.Zamestnanec.Remove(zamestnanec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamestnanecExists(int id)
        {
            return _context.Zamestnanec.Any(e => e.ID == id);
        }
    }
}
