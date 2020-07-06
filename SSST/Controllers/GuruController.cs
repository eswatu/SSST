using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSST.Data;
using SSST.Models;

namespace SSST.Controllers
{
    public class GuruController : Controller
    {
        private readonly SSSTContext _context;

        public GuruController(SSSTContext context)
        {
            _context = context;
        }

        // GET: Guru
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guru.ToListAsync());
        }

        // GET: Guru/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Guru
                .FirstOrDefaultAsync(m => m.GuruID == id);
            if (guru == null)
            {
                return NotFound();
            }

            return View(guru);
        }

        // GET: Guru/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuruID,GuruNama,GuruAlamat")] Guru guru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guru);
        }

        // GET: Guru/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Guru.FindAsync(id);
            if (guru == null)
            {
                return NotFound();
            }
            return View(guru);
        }

        // POST: Guru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuruID,GuruNama,GuruAlamat")] Guru guru)
        {
            if (id != guru.GuruID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuruExists(guru.GuruID))
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
            return View(guru);
        }

        // GET: Guru/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Guru
                .FirstOrDefaultAsync(m => m.GuruID == id);
            if (guru == null)
            {
                return NotFound();
            }

            return View(guru);
        }

        // POST: Guru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guru = await _context.Guru.FindAsync(id);
            _context.Guru.Remove(guru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuruExists(int id)
        {
            return _context.Guru.Any(e => e.GuruID == id);
        }
    }
}
